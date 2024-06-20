using System;
using UnityEngine;
using YG;
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

    public int AdsDays { get; private set; } = 10;
    private int curAdsDays = 0;
    private bool isAds = false;

    public event Action<int> EventUpdateDay;
    public event Action IsEndDays;

    public event Action StartAdsDays;
    public event Action EndAdsDays;

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
        CountDay = SaveDataImpl.instance.LoadSaveCloudInt();
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += StartAds;
        WinChecker.WinCheck += EndDays;
    }

    private void StartAds(int id)
    {
        StartAdsDays?.Invoke();
        if (id != 1)
        {
            return;
        }
        curAdsDays = AdsDays;
        isAds = true;
    }

    void Start()
    {
        //CountDay = SaveDataImpl.instance.LoadSaveCloudInt();
        Counter.instance.IsAddCount += ClickDay;       
    }

    

    private void OnDestroy()
    {
        Counter.instance.IsAddCount -= ClickDay;
        YandexGame.RewardVideoEvent -= StartAds;
        WinChecker.WinCheck -= EndDays;
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
        if (isAds)
        {
            curAdsDays--;
            if (curAdsDays == 0)
            {
                isAds = false;
                EndAdsDays?.Invoke();
            }
        }
        EventUpdateDay?.Invoke(CountDay);
        if (CountDay >= MaxDay)
        {
            EndDays();
        }
        SaveDataImpl.instance.Save(CountDay);
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
