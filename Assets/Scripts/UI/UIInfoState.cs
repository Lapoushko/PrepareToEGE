using TMPro;
using UnityEngine.UI;
using UnityEngine;
using YG;
/// <summary>
/// UI Курса
/// </summary>
public class UIInfoState : MonoBehaviour
{
    [SerializeField] private TMP_Text stamina_text;
    [SerializeField] private TMP_Text motivation_text;
    [SerializeField] private TMP_Text progress_text;

    [SerializeField] private Image staminaImage;
    [SerializeField] private Image motivationImage;
    [SerializeField] private Image progressImage;
    void Start()
    {
        UpdateUI("Math");
        Counter.instance.CourseChanged += UpdateUI;
    }

    private void OnDestroy()
    {
        Counter.instance.CourseChanged -= UpdateUI;
    }

    /// <summary>
    /// Обновить UI
    /// </summary>
    /// <param name="name">имя курса</param>
    private void UpdateUI(string name)
    {
        StateCourse course = Counter.instance.GetCourse(name);

        staminaImage.fillAmount = GetPercent(course.Stamina);
        motivationImage.fillAmount = GetPercent(course.Motivation);
        progressImage.fillAmount = GetPercent(course.Progress);

        stamina_text.text = course.Stamina.ToString("F2");
        motivation_text.text = course.Motivation.ToString("F2");
        progress_text.text = course.Progress.ToString("F2");
    }

    /// <summary>
    /// Получить процент бара
    /// </summary>
    /// <param name="current">Текущее значение</param>
    /// <returns></returns>
    private float GetPercent(float current) => current / 100;
}
