using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Аудио менеджер
/// </summary>
public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;
    int ActiveMusic;
    public bool muteMusic = true;
    public bool muted;

    public static AudioManager instance;
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
        ActiveMusic = PlayerPrefs.GetInt("MusicActive");

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
    }

    /// <summary>
    /// Замьютить музыку
    /// </summary>
    public void MuteMusic()
    {
        this.muteMusic = !this.muteMusic;
        float num = !this.muteMusic ? 0.308f : 0.0f;
        foreach (Sound song in this.sounds)
            song.source.volume = num;
    }

    /// <summary>
    /// Снять мьют
    /// </summary>
    public void UnmuteMusic()
    {
        foreach (Sound sound in this.sounds)
        {
            if (sound.name == "Song")
            {
                sound.source.volume = 1.15f;
                break;
            }
        }
    }

    /// <summary>
    /// Включить музыку
    /// </summary>
    /// <param name="name">название</param>
    public void Play(string name)
    {
        foreach (Sound sound in this.sounds)
        {
            if (sound.name == name)
            {
                sound.source.Play();
                break;
            }
        }
    }
    /// <summary>
    /// Остановить музыку
    /// </summary>
    /// <param name="name">Имя</param>
    public void Stop(string name)
    {
        foreach (Sound sound in this.sounds)
        {
            if (sound.name == name)
            {
                sound.source.Stop();
                break;
            }
        }
    }

    /// <summary>
    /// Изменить питч
    /// </summary>
    /// <param name="id">айди звука</param>
    public void PlayWithPitch(string name)
    {
        for (int i = 0; i < this.sounds.Count; i++)
        {
            if (this.sounds[i].name == name)
            {
                int id = i;
                sounds[id].source.pitch = RandomPitch();
                sounds[id].source.Play();
                break;
            }
        }    
    }
    /// <summary>
    /// Случайное значение для питчинга
    /// </summary>
    /// <returns></returns>
    private float RandomPitch()
    {
        return Random.Range(0.8f, 1.1f);
    }
}