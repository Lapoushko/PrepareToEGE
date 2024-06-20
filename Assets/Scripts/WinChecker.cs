using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Проверщик победы
/// </summary>
public class WinChecker : MonoBehaviour
{
    public static event Action WinCheck;
    private void Start()
    {
        Counter.instance.IsAddCountDictionary += Check;
    }

    private void OnDisable()
    {
        Counter.instance.IsAddCountDictionary -= Check;
    }

    private void Check(Dictionary<string, StateCourse> dictionary)
    {
        float sum = 0;
        foreach (var entry in dictionary)
        {
            StateCourse stateCourse = entry.Value;
            sum += stateCourse.Progress;
        }
        if (sum >= 300)
        {
            WinCheck?.Invoke();
        }
    }
}
