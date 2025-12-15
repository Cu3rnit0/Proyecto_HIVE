using UnityEngine;

public class WhiteboardInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("lista para interacción (futuro)");
        }
    }
}
