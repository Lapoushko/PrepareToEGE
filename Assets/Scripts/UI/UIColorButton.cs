using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Цвет кнопок курса
/// </summary>
public class UIColorButton : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color[] colors;
    [SerializeField] private Image[] images;

    private int id = 0;

    private void Start()
    {
        Counter.instance.CourseChanged += Change;
        images[id].color = colors[id];
    }

    private void OnDisable()
    {
        Counter.instance.CourseChanged -= Change;
    }
    /// <summary>
    /// Смена цвета
    /// </summary>
    /// <param name="obj">имя курса</param>
    private void Change(string obj)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = baseColor;
        }
        switch (obj)
        {
            case "Math":
                id = 0;
                break;
            case "Russian":
                id = 1;
                break;
            case "Info":
                id = 2;
                break;
        }
        images[id].color = colors[id];
    }
}
