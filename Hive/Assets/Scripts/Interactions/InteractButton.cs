using UnityEngine;
using UnityEngine.UI;


public class InteractButton : MonoBehaviour
{
    public Button BtnInteract;

    void Start()
    {
        BtnInteract.onClick.AddListener(OnInteract);
    }


    void OnInteract()
    {
        Debug.Log("INTERACT Button clicked");
    }
}
