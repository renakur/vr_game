using UnityEngine;
using static LightCatcher;

[CreateAssetMenu(fileName = "LQ_WaitForSequence", menuName = "Scriptable Objects/LQ_WaitForSequence")]
public class LQ_WaitForSequence : QuestObjective
{
    public LightColors lightColor;
    public override void Execute()
    {
        if (LightCatcher.Instance != null)
        {
            LightCatcher.Instance.ResetAllButtons();
            LightCatcher.Instance.TurnOnLight(lightColor); 
        }
    }

    public override void OnUpdate()
    {
        if (LightCatcher.Instance == null) return;

        if (LightCatcher.Instance.IsButtonColorPressed(lightColor))
        {
            LightCatcher.Instance.ResetAllButtons();
            EndExecution();
        }
        else
        {
            LightCatcher.Instance.TurnOnLight(LightColors.red);
        }
    }
}
