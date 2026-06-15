using UnityEngine;

[CreateAssetMenu(fileName = "LQ_OpenTheDoor", menuName = "Scriptable Objects/LQ_OpenTheDoor")]
public class LQ_OpenTheDoor : QuestObjective
{
    public override void Execute()
    {
        DoorVisuals.Instance.StartAnimation();
        EndExecution();
    }
    public override void OnUpdate()
    {

    }
}
