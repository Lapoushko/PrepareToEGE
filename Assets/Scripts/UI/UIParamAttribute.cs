using UnityEngine;
/// <summary>
/// Информация об аттрибутах
/// </summary>
public class UIParamAttribute : MonoBehaviour
{
    private ClickAttribute clickAttribute;
    [SerializeField] private GameObject[] imageUp;
    [SerializeField] private GameObject[] imageDown;
    [SerializeField] private string type;

    private void Start()
    {
        clickAttribute = GetComponentInParent<ClickAttribute>();
        SetMetrick(GetValue());
    }
    /// <summary>
    /// Получить значение
    /// </summary>
    /// <returns>Значение</returns>
    private float GetValue()
    {
        return type switch
        {
            "Stamina" => clickAttribute.GetStamina(),
            "Motivation" => clickAttribute.GetMotivation(),
            "Progress" => clickAttribute.GetProgress(),
            _ => 0,
        };
    }
    /// <summary>
    /// Установить метрику
    /// </summary>
    private void SetMetrick(float value)
    {
        /// коэф считается как (3 - максимальное значение) / множитель.
        /// вычитаем 0.001f так как иначе при 3 получается 0.(3

        float coef = ((5f / Multiplier.startDelimiter)) / 5f ;
        if (value != 0 || value >= 5 * coef || value <= 5 * -coef)
        {
            if (value > 0)
            {
                for (int i = 0; i < imageUp.Length; i++)
                {
                    if ((value > i * coef) && (value <= (i + 1) * coef))
                    {
                        imageUp[i].SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < imageUp.Length; i++)
                {
                    if ((value < i * -coef) && (value >= (i + 1) * -coef))
                    {
                        imageDown[i].SetActive(true);
                        break;
                    }
                }
            }
        }
        if (value > 5 * coef)
        {
            imageUp[4].SetActive(true);
        }
        else if (value < 5 * -coef)
        {
            imageDown[4].SetActive(true);
        }
    }

}
