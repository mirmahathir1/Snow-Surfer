using UnityEngine;
using UnityEngine.EventSystems;

public class RotationButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] PlayerController playerController;
    [SerializeField] float direction = 1f; // 1 = rotate right (R button), -1 = rotate left (L button)

    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.SetMobileRotation(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.SetMobileRotation(0f);
    }
}
