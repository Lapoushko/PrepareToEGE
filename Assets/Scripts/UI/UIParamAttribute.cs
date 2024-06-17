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
        switch (type)
        {
            case "Stamina":
                return clickAttribute.GetStamina();
            case "Motivation":
                return clickAttribute.GetMotivation();
            case "Progress":
                return clickAttribute.GetProgress();
            default: return 0;
        }
    }
    /// <summary>
    /// Установить метрику
    /// </summary>
    private void SetMetrick(float value)
    {
        if (value >= 0 && value < 2)
        {
            imageUp[0].SetActive(true);
        }
        else if (value >= 2 && value < 3)
        {
            imageUp[1].SetActive(true);
        }
        else if (value >= 3)
        {
            imageUp[2].SetActive(true);
        }

        if (value < 0 && value > -2)
        {
            imageDown[0].SetActive(true);
        }
        else if (value <= -2 && value > -3)
        {
            imageDown[1].SetActive(true);
        }
        else if (value <= -3)
        {
            imageDown[2].SetActive(true);
        }
    }
}
