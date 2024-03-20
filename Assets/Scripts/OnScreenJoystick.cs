using UnityEngine;
using UnityEngine.EventSystems;

public class OnScreenJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickHandle;

    private Vector2 joystickInput = Vector2.zero;

    public Vector2 JoystickInput => joystickInput;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBackground.sizeDelta.x);
            pos.y = (pos.y / joystickBackground.sizeDelta.y);

            float x = (joystickBackground.pivot.x == 1f) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (joystickBackground.pivot.y == 1f) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            joystickInput = new Vector2(x, y).normalized;

            // Clamp joystick handle inside the background
            Vector2 joystickPosition = new Vector2(joystickInput.x * (joystickBackground.sizeDelta.x / 2), joystickInput.y * (joystickBackground.sizeDelta.y / 2));
            joystickHandle.anchoredPosition = joystickPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickInput = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}
