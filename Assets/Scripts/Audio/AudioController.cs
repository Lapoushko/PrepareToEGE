using System;
using UnityEngine;
/// <summary>
/// Контроллер звуков игры
/// </summary>
public class AudioController : MonoBehaviour
{
    [SerializeField] private string[] musics;
    [SerializeField] private string[] clicks;
    [SerializeField] private string[] swipes;
    private void OnEnable()
    {
        ClickAttribute.onClickMusic += PlaySound;
        ChangeCourse.onClickMusic += PlaySwipe;
    }

    private void OnDisable()
    {
        ClickAttribute.onClickMusic -= PlaySound;
        ChangeCourse.onClickMusic += PlaySwipe;
    }

    /// <summary>
    /// Включать рандомный звук
    /// </summary>
    private void PlaySound()
    {
        System.Random random = new System.Random();
        AudioManager.instance.PlayWithPitch(clicks[random.Next(0, clicks.Length)]);
    }

    /// <summary>
    /// Включать рандомный свайп
    /// </summary>
    private void PlaySwipe()
    {
        System.Random random = new System.Random();
        AudioManager.instance.Play(swipes[random.Next(0, swipes.Length)]);
    }

    void Start()
    {
        System.Random random = new System.Random();
        AudioManager.instance.Play(musics[random.Next(0, musics.Length)]);
    }
}
