using UnityEngine;

[CreateAssetMenu(fileName = "LQ_ShowPopup", menuName = "Scriptable Objects/LQ_ShowPopup")]
public class LQ_ShowPopup : QuestObjective
{
    
   
    public override void Execute()
    {
        
        Popup.Instance.ShowPopup();
    }

    public override void OnUpdate()
    {
        if (Popup.Instance._startMinigame)
        {
            EndExecution();
        }
    }

    

}
