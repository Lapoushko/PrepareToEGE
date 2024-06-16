using System;

/// <summary>
/// Состояние курса
/// </summary>
public class StateCourse
{
    /// <summary>
    /// Имя курса
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Выносливость
    /// </summary>
    public float Stamina { get; private set; }
    /// <summary>
    /// Мотивация учиться
    /// </summary>
    public float Motivation { get; private set; }
    /// <summary>
    /// Прогресс обучения
    /// </summary>
    public float Progress { get; private set; }

    /// <summary>
    /// Добавляющее к общему результату
    /// true - Добавляет, не проходит проверки
    /// false - Не добавляет, не проходит проверки
    /// </summary>
    public bool Adding {  get; private set; }

    public StateCourse(
        bool adding,
        string name,
        float stamina,
        float motivation,
        float progress
        )
    {
        Adding = adding;
        Name = name;
        SetStamina(stamina);
        SetMotivation(motivation);
        SetProgress(progress);
    }
    /// <summary>
    /// Установить лимит выносливости
    /// </summary>
    /// <param name="value">выносливость</param>
    private void SetStamina(float value)
    {
        int min = (Adding) ? -100 : 0;
        Stamina = Math.Clamp(value, min, 100);
    }

    /// <summary>
    /// Установить лимит мотивации
    /// </summary>
    /// <param name="value">мотивации</param>
    private void SetMotivation(float value)
    {
        int min = (Adding) ? -100 : 0;
        Motivation = Math.Clamp(value, min, 100);
    }

    /// <summary>
    /// Установить лимит прогресса
    /// </summary>
    /// <param name="value">прогресс</param>
    private void SetProgress(float value)
    {
        int min = (Adding) ? -100 : 0;
        Progress = Math.Clamp(value, min, 100);
    }
}
