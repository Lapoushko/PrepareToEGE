using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI Смена предмета
/// </summary>
public class ClickAttribute : MonoBehaviour
{
    [SerializeField] private int dayForActivate = 0;
    public int CountClick { get; private set; } = 0;
    public event Action UniqClick;

    [SerializeField] private float stamina;
    [SerializeField] private float motivation;
    [SerializeField] private float progress;

    [SerializeField] private GameObject backgroundOriginal;
    [SerializeField] private Sprite backgroundImage;
    [SerializeField] private string description;

    public static Action clickEvent;
    public static Action<int> openButtonEvent;
    private int multiplier = 5;

    [SerializeField] private bool isAds;

    /// <summary>
    /// Смена предмета
    /// </summary>
    public void OnClick()
    {
        StateCourse newState = new StateCourse(
            true, null, stamina, motivation, progress);
        Counter.instance.AddCount(newState);
        backgroundOriginal.GetComponent<SpriteRenderer>().sprite =
            backgroundImage;
        clickEvent?.Invoke();
        UniqClick?.Invoke();
        CountClick++;
        Scaling();
        if (isAds)
        {
            AdsBonusRewarded.TryShowFullscreenAdWithChance(5);
            AdsBonusRewarded.ShowRewardedAd(1);
        }
    }

    public void SubscribeOnClick(Action action)
    {
        UniqClick += action;
    }

    public void UnsubscribeOnClick(Action action)
    {
        UniqClick -= action;
    }

    private void Awake()
    {
        multiplier = Multiplier.multiplier;
        int startdel = Multiplier.startDelimiter;
        stamina /= startdel;
        motivation /= startdel;
        progress /= startdel;
    }

    private void Start()
    {
        CounterDay.instance.EventUpdateDay += Activate;
        CounterDay.instance.StartAdsDays += SetMultiplier;
        CounterDay.instance.EndAdsDays += NoMultiplier;     
        Activate(0);
    }

    private void SetMultiplier()
    {
        stamina *= multiplier;
        motivation *= multiplier;
        progress *= multiplier;
    }

    private void NoMultiplier()
    {
        stamina /= multiplier;
        motivation /= multiplier;
        progress /= multiplier;
    }

    private void OnDestroy()
    {
        CounterDay.instance.EventUpdateDay -= Activate;
        CounterDay.instance.StartAdsDays -= SetMultiplier;
        CounterDay.instance.EndAdsDays -= NoMultiplier;
    }

    private void Scaling()
    {
        DOtweenScaling.Resizing(transform, 16f, 0.2f, 0.2f);
    }

    /// <summary>
    /// Активация кнопки
    /// </summary>
    /// <param name="day"></param>
    private void Activate(int day)
    {
        if (day >= dayForActivate)
        {
            var button = gameObject.GetComponent<Button>();
            button.interactable = true;
            gameObject.GetComponent<Image>().color = Color.white;
            gameObject.GetComponentInChildren<TMP_Text>().text = GetDescription(description);
            openButtonEvent?.Invoke(day);
            CounterDay.instance.EventUpdateDay -= Activate;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
            gameObject.GetComponentInChildren<TMP_Text>().text = "Закрыто";
        }
    }

    public float GetStamina()
    {
        return stamina;
    }
    public float GetMotivation()
    {
        return motivation;
    }
    public float GetProgress()
    {
        return progress;
    }

    /// <summary>
    /// Правильный формат текста
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    private string GetDescription(string description) => description.Replace(" ", "\r\n");
}