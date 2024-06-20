using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

/// <summary>
/// Панель конца игры
/// </summary>
public class UIEndGame : MonoBehaviour
{
    [SerializeField] private float winnerSum = 0;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private Sprite winImage;
    [SerializeField] private Sprite loseImage;

    [SerializeField] private TMP_Text resultText;
    [SerializeField] private Image resultImage;
    [SerializeField] private TMP_Text winnerSumText;
    [SerializeField] private GameObject spendDays;
    [SerializeField] private GameObject scoreObj;

    [SerializeField] private Gradient gradient;
    public static Action<bool> WinGame;

    private float sum;
    private void Start()
    {
        CounterDay.instance.IsEndDays += EndGame;
    }

    private void OnDisable()
    {
        CounterDay.instance.IsEndDays -= EndGame;
    }

    /// <summary>
    /// Конец игры
    /// </summary>
    private void EndGame()
    {
        sum = 0;
        Dictionary<string, StateCourse> courses = Counter.instance.GetCourses();
        foreach (var course in courses)
        {
            sum += course.Value.Progress;
        }

        panelWin.SetActive(true);

        if (sum >= winnerSum) 
        {
            WinGame?.Invoke(true);
            panelWin.GetComponent<Image>().sprite = winImage;
            var score = (CounterDay.instance.MaxDay - CounterDay.instance.CountDay) * 2;

            SaveDataImpl.instance.Save(score);

            spendDays.SetActive(true);
            spendDays.GetComponent<TMP_Text>().text = "Потрачено дней: " + CounterDay.instance.CountDay.ToString();

            scoreObj.SetActive(true);
            scoreObj.GetComponent<TMP_Text>().text = "Количество очков: " + score.ToString();
        }
        else
        {
            WinGame?.Invoke(false);          
            panelWin.GetComponent<Image>().sprite = loseImage;
        }
        ResultBar();
    }
    /// <summary>
    /// Рестарт игры
    /// </summary>
    public void OnClickRestart()
    {
        SaveDataImpl.instance.DeleteData();
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// Конечный бар
    /// </summary>
    private void ResultBar()
    {
        resultImage.fillAmount = GetPercent(sum);
        resultText.text = sum.ToString("F1");
        winnerSumText.text = winnerSum.ToString();
        resultImage.color = gradient.Evaluate(GetPercent(sum));
    }

    /// <summary>
    /// Получить процент бара
    /// </summary>
    /// <param name="current">Текущее значение</param>
    /// <returns></returns>
    private float GetPercent(float current) => current / winnerSum;
}
