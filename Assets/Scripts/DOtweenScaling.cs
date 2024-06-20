using DG.Tweening;
using UnityEngine;

/// <summary>
/// Изменение размера с анимацией объекта
/// </summary>
public class DOtweenScaling : MonoBehaviour
{
    /// <summary>
    /// Увеличение
    /// </summary>
    /// <param name="obj">объект</param>
    /// <param name="scale">размер</param>
    /// <param name="time">время</param>
    public static void Increasing(Transform obj, float scale, float time)
    {
        obj.DOScale(scale, time).SetEase(Ease.InQuad);
    }
    /// <summary>
    /// Уменьшение
    /// </summary>
    /// <param name="obj">объект</param>
    /// <param name="time">время</param>
    public static void Decreasing(Transform obj, float time)
    {
        obj.DOScale(1f, time).SetEase(Ease.InQuad);
    }

    /// <summary>
    /// Изменение размера объекта
    /// </summary>
    /// <param name="obj">объект</param>
    /// <param name="scale">размер увеличения</param>
    /// <param name="timeIncrease">время увеличения</param>
    /// <param name="timeDecreasing">время уменьшения</param>
    public static void Resizing(Transform obj, float scale, float timeIncrease, float timeDecreasing)
    {
        obj.DOScale(scale,timeIncrease).SetEase(Ease.InQuad);
        obj.DOScale(1f, timeDecreasing).SetEase(Ease.InQuad);
    }
}
