using System;
using UnityEngine;
/// <summary>
/// Счётчик дней до экзамена
/// </summary>
public class CounterDay : MonoBehaviour
{
    private int clickDay = 0;
    public static CounterDay instance;
    public bool IsGameEnd { get; private set; } = false;
    public int CountDay { get; private set; } = 0;
    public int MaxDay { get; private set; } = 365;
    public event Action<int> EventUpdateDay;
    public event Action IsEndDays;
    [SerializeField] private int moddingDay = 5;

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

    void Start()
    {
        Counter.instance.IsAddCount += ClickDay;
    }

    private void OnDestroy()
    {
        Counter.instance.IsAddCount -= ClickDay;
    }
    
    /// <summary>
    /// Клик на действие дня
    /// </summary>
    private void ClickDay()
    {
        clickDay += 1;
        if (clickDay == moddingDay)
        {
            UpdateDay();
            clickDay = 0;
            if (CountDay >= MaxDay)
            {
                IsGameEnd = true;
            }
        }
    }

    /// <summary>
    /// Обновить количество дней
    /// </summary>
    private void UpdateDay()
    {
        CountDay++;
        EventUpdateDay?.Invoke(CountDay);
        if (CountDay >= MaxDay)
        {
            EndDays();
        }
    }

    /// <summary>
    /// Закончились дни до экзамена
    /// </summary>
    private void EndDays()
    {
        IsGameEnd = true;
        IsEndDays?.Invoke();
    }
}
