using UnityEngine;
using UnityEngine.EventSystems;

public class LookInput : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 LookDelta { get; private set; }

    private bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        LookDelta = eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        LookDelta = Vector2.zero;
    }

    void LateUpdate()
    {
        // Evita acumulación infinita
        LookDelta = Vector2.zero;
    }
}
