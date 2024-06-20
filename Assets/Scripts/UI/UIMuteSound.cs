using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI мьют звука
/// </summary>
public class UIMuteSound : MonoBehaviour
{
    [SerializeField] private Sprite[] images;

    public static event Action MuteSoundEvent;

    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = images[PlayerPrefs.GetInt("Sound")];
    }

    /// <summary>
    /// Клик на кнопку
    /// </summary>
    public void Click()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            gameObject.GetComponent<Image>().sprite = images[1];
            MuteSoundEvent?.Invoke();
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            gameObject.GetComponent<Image>().sprite = images[0];
            MuteSoundEvent?.Invoke();
        }
    }
}
