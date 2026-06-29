using UnityEngine;

[CreateAssetMenu(fileName = "LQ_OpenTheDoor", menuName = "Scriptable Objects/LQ_OpenTheDoor")]
public class LQ_OpenTheDoor : QuestObjective
{
    public override void Execute()
    {
        if (DoorVisuals.Instance != null)
        {
            DoorVisuals.Instance.StartAnimation();
        }
        else
        {
            Debug.LogError("[QUEST] null");
        }

        EndExecution();
    }
 

    public override void OnUpdate()
    {

    }
}
