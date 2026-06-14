using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LQ_CheckSequence", menuName = "Scriptable Objects/LQ_CheckSequence")]
public class LQ_CheckSequence : QuestObjective
{
    public List<LightColors> sequence;

    public override void Execute()
    {
        if (SequenceManager.Instance != null)
        {
            
            SequenceManager.Instance.StartPuzzle(sequence);
        }
    }

    public override void OnUpdate()
    {
        if (SequenceManager.Instance == null) return;

        if (SequenceManager.Instance.isPuzzleCompleted)
        {
            EndExecution(); 
        }
    }
}
