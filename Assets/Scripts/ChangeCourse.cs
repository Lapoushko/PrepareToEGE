using UnityEngine;

/// <summary>
/// Кнопка смены курса обучения
/// </summary>
public class ChangeCourse : MonoBehaviour
{
    /// <summary>
    /// Смена
    /// </summary>
    /// <param name="newCourse">название предмета</param>
    public void OnClickChangeCourse(string newCourse)
    {
        Counter.instance.ChangeCourse(newCourse);
    }
}
