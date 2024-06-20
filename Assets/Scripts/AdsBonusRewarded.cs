using System;
using TMPro;
using UnityEngine;
using YG;
/// <summary>
/// Обработка рекламы
/// </summary>
public class AdsBonusRewarded : MonoBehaviour
{
    public static Action RewardedMultiplierStart;

    private void Start()
    {
        CounterDay.instance.EndAdsDays += EndAds;
        CounterDay.instance.StartAdsDays += StartAds;
        gameObject.GetComponentInChildren<TMP_Text>().text = "Выпить \r\nкофе\r\n(Увеличить \r\nмножитель \r\nкликов x" + Multiplier.multiplier + ")";
    }

    private void StartAds()
    {
        gameObject.SetActive(false);
    }

    private void EndAds()
    {
        gameObject.SetActive(true);
    }

    public static void TryShowFullscreenAdWithChance(int chance)
    {
        var random = UnityEngine.Random.Range(0, 101);
        if (chance < random)
        {
            return;
        }
        YandexGame.FullscreenShow();
    }

    public static void ShowRewardedAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    /// <summary>
    /// Кнопка бонуса множителя
    /// </summary>
    public void OnClickRewardedMultiplier()
    {
        ShowRewardedAd(1);       
        RewardedMultiplierStart?.Invoke();
    }
}
