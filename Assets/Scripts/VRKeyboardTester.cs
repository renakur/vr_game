using UnityEngine;

public class VRKeyboardTester : MonoBehaviour
{
    [SerializeField] private ButtonTrigger yellow;
    [SerializeField] private ButtonTrigger blue;
    [SerializeField] private ButtonTrigger purple;
    [SerializeField] private ButtonTrigger orange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && yellow != null)
        {
            Debug.Log("[Tester] yellow");
            yellow.PressButton(); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && blue != null)
        {
            Debug.Log("[Tester] blue");
            blue.PressButton();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && purple != null)
        {
            Debug.Log("[Tester] purple");
            purple.PressButton();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && orange != null)
        {
            Debug.Log("[Tester] orange");
            orange.PressButton();
        }
    }
}
