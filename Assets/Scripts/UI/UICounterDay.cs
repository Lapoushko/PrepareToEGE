using TMPro;
using UnityEngine;
/// <summary>
/// UI счётчика дней
/// </summary>
public class UICounterDay : MonoBehaviour
{
    private TMP_Text counterText;
    private void Start()
    {
        counterText = GetComponent<TMP_Text>();
        counterText.text = "Осталось до экзамена: 365";
        CounterDay.instance.EventUpdateDay += UpdateCurrentDay;
    }

    private void OnDestroy()
    {
        CounterDay.instance.EventUpdateDay -= UpdateCurrentDay;
    }

    /// <summary>
    /// Обновить количество дней
    /// </summary>
    /// <param name="day">день</param>
    private void UpdateCurrentDay(int day)
    {
        counterText.text = "Осталось до экзамена: " + (365 - day);
    }
}
