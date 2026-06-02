using UnityEngine;

[CreateAssetMenu(fileName = "LQ_PlayLightsCombination", menuName = "Scriptable Objects/LQ_PlayLightsCombination")]
public class LQ_PlayLightsCombination : QuestObjective
{
    [SerializeField] private string light;
    

    public override void Execute()
    {
        ButtonsData.Instance.LightShowcase(light);
        EndExecution();
    }

    public override void OnUpdate()
    {

    }
}
