using UnityEngine;
using UnityEngine.EventSystems;

public class BoostButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.SetMobileBoost(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.SetMobileBoost(false);
    }
}
