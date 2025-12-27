using UnityEngine;

public class ConveyorButton : MonoBehaviour
{
    [Header("Action")]
    public ConveyorButtonAction action;

     void OnMouseDown()
    {
        Execute();
    }
    void Execute()
    {
        switch (action)
        {
            case ConveyorButtonAction.RetunrOffice_Test:
                SceneLoader.Instance.LoadOffice();
                break;

            case ConveyorButtonAction.GoConferenceRoom_Test:
                SceneLoader.Instance.loadConferenceRoom(); 
                break;
        }
    }

}

public enum ConveyorButtonAction
{
    RetunrOffice_Test,
    GoConferenceRoom_Test
}
