/// <summary>
/// расчёт коэффициентов 
/// </summary>
public class CalculatorCoef
{
    /// <summary>
    /// Подсчёт прогресса
    /// </summary>
    public class CalculateProgress : Calculator
    {
        public override float GetCoef(StateCourse stateCourse, float oldValue, float newValue)
        {
            return (stateCourse.Stamina > 0) 
                ? oldValue + (newValue * (stateCourse.Motivation / 100)) 
                : oldValue;
        }
    }

    /// <summary>
    /// Подсчёт выносливости
    /// </summary>
    public class CalculateStamina : Calculator
    {
        public override float GetCoef(StateCourse stateCourse, float oldValue, float newValue)
        {
            return oldValue + newValue;
        }
    }

    /// <summary>
    /// Подсчёт мотивации
    /// </summary>
    public class CalculateMotivation : Calculator
    {
        public override float GetCoef(StateCourse stateCourse, float oldValue, float newValue)
        {
            return (stateCourse.Stamina > 0)
                ? oldValue + newValue
                : oldValue;
        }
    }
}

