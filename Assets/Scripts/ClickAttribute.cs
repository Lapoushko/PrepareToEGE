using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI Смена предмета
/// </summary>
public class ClickAttribute : MonoBehaviour
{
    [SerializeField] private int dayForActivate = 0;

    [SerializeField] private float stamina;
    [SerializeField] private float motivation;
    [SerializeField] private float progress;

    [SerializeField] private string nameSound;
    [SerializeField] private GameObject backgroundOriginal;
    [SerializeField] private Sprite backgroundImage;

    /// <summary>
    /// Смена предмета
    /// </summary>
    public void OnClick()
    {
        StateCourse newState = new StateCourse(
            true, null, stamina, motivation, progress);
        Counter.instance.AddCount(newState);
        AudioManager.instance.Play(nameSound);
        backgroundOriginal.gameObject.GetComponent<SpriteRenderer>().sprite =
            backgroundImage;
    }

    private void Start()
    {
        CounterDay.instance.EventUpdateDay += Activate;
        stamina /= 5;
        motivation /= 5;
        progress /= 5;
        Activate(0);
    }

    private void OnDestroy()
    {
        CounterDay.instance.EventUpdateDay -= Activate;
    }
    /// <summary>
    /// Активация кнопки
    /// </summary>
    /// <param name="day"></param>
    private void Activate(int day)
    {
        if (day >= dayForActivate)
        {
            gameObject.GetComponent<Button>().interactable = true;
            CounterDay.instance.EventUpdateDay -= Activate;
        }
    }
}
