using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,
    IDragHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public RectTransform handle;
    public float maxDistance = 100f;

    private Vector2 input;

    public float Horizontal => input.x;
    public float Vertical => input.y;

    // CUANDO SE ARRASTRA
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)transform,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );

        position = Vector2.ClampMagnitude(position, maxDistance);
        handle.anchoredPosition = position;
        input = position / maxDistance;
    }

    // CUANDO TOCAS EL JOYSTICK
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    // CUANDO SUELTAS EL JOYSTICK
    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
        input = Vector2.zero;
    }
}
