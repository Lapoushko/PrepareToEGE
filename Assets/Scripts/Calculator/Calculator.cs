/// <summary>
/// Калькулятор
/// </summary>
public abstract class Calculator
{
    /// <summary>
    /// Получить коэфициент
    /// </summary>
    /// <param name="stateCourse">Текущее состояние</param>
    /// <param name="oldValue">текущее значение</param>
    /// <param name="newValue">добавочное значение</param>
    /// <returns></returns>
    public abstract float GetCoef(StateCourse stateCourse ,float oldValue, float newValue);
}