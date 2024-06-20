using System.Collections.Generic;
using UnityEngine;
using YG;

/// <summary>
/// Сохранения 
/// </summary>
public class SaveDataImpl : MonoBehaviour, SaveData, LoadData, DeleteData
{
    public static SaveDataImpl instance;

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
        DontDestroyOnLoad(gameObject);
    }

    public int LoadSaveCloudDict()
    {
        return YandexGame.savesData.courseDict;
    }


    public int LoadSaveCloudInt()
    {
        return YandexGame.savesData.countDay;
    }

    public void Save(Dictionary<string, StateCourse> dict)
    {
        YandexGame.savesData.courseDict = (int)dict["Math"].Stamina;   
        YandexGame.SaveProgress();
    }

    public void Save(int countDay)
    {
        YandexGame.savesData.countDay = countDay;
        YandexGame.SaveProgress();
    }

    public void DeleteData()
    {
        YandexGame.ResetSaveProgress();
    }

    public void Save(float score)
    {
        if (score >= YandexGame.savesData.maxScore)
        {
            YandexGame.savesData.maxScore = score;            
            YandexGame.NewLeaderboardScores("Score", (int)score);
            YandexGame.SaveProgress();
        }
    }
}

/// <summary>
/// Сохранение
/// </summary>
interface SaveData
{
    /// <summary>
    /// Сохранение курсов
    /// </summary>
    /// <param name="dict">курсы</param>
    void Save(Dictionary<string, StateCourse> dict);

    /// <summary>
    /// Сохранение количества дней
    /// </summary>
    /// <param name="countDay">количество дней</param>
    void Save(int countDay);

    /// <summary>
    /// Сохранение максимального значения
    /// </summary>
    /// <param name="score">количество очков</param>
    void Save(float score);
}

interface LoadData
{
    /// <summary>
    /// Загрузка данных курсов
    /// </summary>
    /// <returns>курсы</returns>
    int LoadSaveCloudDict();

    /// <summary>
    /// Загрузка данных количества дней
    /// </summary>
    /// <returns>количество дней</returns>
    int LoadSaveCloudInt();
}

interface DeleteData
{
    /// <summary>
    /// Удалить данные
    /// </summary>
    void DeleteData();
}
