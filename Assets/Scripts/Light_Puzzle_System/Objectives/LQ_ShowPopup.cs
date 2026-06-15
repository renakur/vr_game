using UnityEngine;

[CreateAssetMenu(fileName = "LQ_ShowPopup", menuName = "Scriptable Objects/LQ_ShowPopup")]
public class LQ_ShowPopup : QuestObjective
{
    public override void Execute()
    {
        Popup.Instance.infoPopupCanvas.SetActive(true);
    }

    public override void OnUpdate()
    {

    }

}
