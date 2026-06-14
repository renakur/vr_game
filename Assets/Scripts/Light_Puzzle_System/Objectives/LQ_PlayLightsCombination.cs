using UnityEngine;

[CreateAssetMenu(fileName = "LQ_PlayLightsCombination", menuName = "Scriptable Objects/LQ_PlayLightsCombination")]
public class LQ_PlayLightsCombination : QuestObjective
{
    public LightColors lightColor;
    public override void Execute()
    {

        LightCatcher.Instance.TurnOnLight(lightColor);
    }

    public override void OnUpdate()
    {
        if (PuzzleLight.Instance.showcaseEnded)
        {
            EndExecution();
        }
    }

    
}
