using System;
using System.Collections;
using UnityEngine;
/// <summary>
/// Контроллер звуков игры
/// </summary>
public class AudioController : MonoBehaviour
{
    [SerializeField] private string[] musics;
    [SerializeField] private string[] clicks;
    [SerializeField] private string[] swipes;
    [SerializeField] private string[] winsound;
    [SerializeField] private string openButton;
    void Start()
    {
        System.Random random = new System.Random();
        AudioManager.instance.Play(musics[random.Next(0, musics.Length)]);

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioManager.instance.MuteMusic();
        }      
    }

    private void OnEnable()
    {
        ClickAttribute.openButtonEvent += PlayOpenButton;
        ClickAttribute.clickEvent += PlaySound;
        ChangeCourse.onClickMusic += PlaySwipe;
        UIEndGame.WinGame += WinGame;
        UIMuteSound.MuteSoundEvent += Mute;
    }
    /// <summary>
    /// Включение звука
    /// </summary>
    /// <param name="type">1 - включён, 0 - выключен</param>
    /// <exception cref="NotImplementedException"></exception>
    private void Mute()
    {
        AudioManager.instance.MuteMusic();
    }

    /// <summary>
    /// Звук победы
    /// </summary>
    /// <param name="obj">Победа или нет</param>
    private void WinGame(bool obj)
    {
        int index = obj ? 0 : 1;
        AudioManager.instance.Play(winsound[index]);
    }

    private void OnDisable()
    {
        ClickAttribute.openButtonEvent -= PlayOpenButton;
        ClickAttribute.clickEvent -= PlaySound;
        ChangeCourse.onClickMusic += PlaySwipe;
        UIEndGame.WinGame -= WinGame;
        UIMuteSound.MuteSoundEvent -= Mute;
    }

    /// <summary>
    /// Включать рандомный звук
    /// </summary>
    public void PlaySound()
    {
        System.Random random = new System.Random();
        AudioManager.instance.PlayWithPitch(clicks[random.Next(0, clicks.Length)]);
    }

    /// <summary>
    /// Включать звук открытия кнопки
    /// </summary>
    private void PlayOpenButton(int day)
    {
        if (day != 0)
        {
            System.Random random = new System.Random();
            AudioManager.instance.Play(openButton);
        }      
    }

    /// <summary>
    /// Включать рандомный свайп
    /// </summary>
    private void PlaySwipe()
    {
        System.Random random = new System.Random();
        AudioManager.instance.Play(swipes[random.Next(0, swipes.Length)]);
    }
}
