using TMPro;
using UnityEngine;
/// <summary>
/// Открытие новой кнопки
/// </summary>
public class UIOpenCloseBTN : MonoBehaviour
{
    private int countClick;
    //private TMP_Text text
    private void Start()
    {
        var clickAttributeComponent = GetComponentInParent<ClickAttribute>();

        if (clickAttributeComponent != null)
        {
            clickAttributeComponent.SubscribeOnClick(click);
        }
    }

    private void OnDestroy()
    {
        var clickAttributeComponent = GetComponentInParent<ClickAttribute>();
        if (clickAttributeComponent != null)
        {
            clickAttributeComponent.UnsubscribeOnClick(click);
        }
    }

    private void click()
    {
        countClick++;
        //Debug.Log("Button clicked! " + countClick);
    }
}
