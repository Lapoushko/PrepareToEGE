using UnityEditor.Compilation;
using UnityEngine;

/// <summary>
/// расчёт коэффициентов 
/// </summary>
public class CalculatorCoef : Calculator
{
    protected override float GetCoef(float oldValue, float newValue)
    {
        throw new System.NotImplementedException();
    }
}

abstract class Calculator
{
    protected abstract float GetCoef(float oldValue, float newValue);
}
