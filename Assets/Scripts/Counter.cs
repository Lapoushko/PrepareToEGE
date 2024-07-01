using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

/// <summary>
/// Счётчик очков Singleton
/// </summary>
public class Counter : MonoBehaviour
{
    public static Counter instance;

    private Dictionary<string, StateCourse> courseDict = new Dictionary<string, StateCourse>();
    private string nameCourse = "Math";

    public event Action<string> CourseChanged;
    public event Action IsAddCount;

    public event Action<Dictionary<string, StateCourse>> IsAddCountDictionary;

    void Awake()
    {       
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }      
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += Load;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Load;
    }

    private void Load()
    {
        courseDict = new Dictionary<string, StateCourse>()
        {
            [NamesCourses.Math] = SaveDataImpl.instance.LoadSaveCloudDict(NamesCourses.Math),
            [NamesCourses.Russian] = SaveDataImpl.instance.LoadSaveCloudDict(NamesCourses.Russian),
            [NamesCourses.Info] = SaveDataImpl.instance.LoadSaveCloudDict(NamesCourses.Info)
        };
    }

    /// <summary>
    /// Добавить очки обучения
    /// </summary>
    /// <param name="addState">Добавленное состояние</param>
    public void AddCount(StateCourse addState)
    {
        CheckExistCourse(nameCourse);
        float stamina = new CalculatorCoef.CalculateStamina().GetCoef(
            courseDict[nameCourse],
            courseDict[nameCourse].Stamina,
            addState.Stamina);

        float motivation = new CalculatorCoef.CalculateMotivation().GetCoef(
            courseDict[nameCourse],
            courseDict[nameCourse].Motivation,
            addState.Motivation);

        float progress = new CalculatorCoef.CalculateProgress().GetCoef(
            courseDict[nameCourse],
            courseDict[nameCourse].Progress,
            addState.Progress);

        courseDict[nameCourse] = new StateCourse(
            false,
            nameCourse,
            stamina,
            motivation,
            progress);
        IsAddCountDictionary?.Invoke(courseDict);
        IsAddCount?.Invoke();
        CourseChanged?.Invoke(nameCourse);
        SaveDataImpl.instance.Save(courseDict[nameCourse]);
    }
    /// <summary>
    /// Смена курса
    /// </summary>
    /// <param name="name">имя курса</param>
    public void ChangeCourse(string name)
    {
        nameCourse = name;
        CourseChanged?.Invoke(nameCourse);
    }

    /// <summary>
    /// Получить курс
    /// </summary>
    /// <param name="name">имя курса</param>
    /// <returns></returns>
    public StateCourse GetCourse(string name)
    {
        CheckExistCourse(name);
        return courseDict[name];
    }

    /// <summary>
    /// Геттер всех курсов
    /// </summary>
    /// <returns>все курсы</returns>
    public Dictionary<string, StateCourse> GetCourses()
    {
        return courseDict;
    }

    /// <summary>
    /// Проверка на существование курса
    /// </summary>
    /// <param name="name">имя курса</param>
    private void CheckExistCourse(string name)
    {
        if (!courseDict.ContainsKey(name))
        {
            courseDict[name] = SaveDataImpl.instance.LoadSaveCloudDict(name);
        }
    }
}
