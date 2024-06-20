using UnityEngine;
using YG;
/// <summary>
/// Оценка игры
/// </summary>
public class SentGame : MonoBehaviour
{
    /// <summary>
    /// Дать оценку
    /// </summary>
    public void Sent()
    {
        if (YandexGame.SDKEnabled)
        {
            YandexGame.ReviewShow(true);
        }
    }
}
 