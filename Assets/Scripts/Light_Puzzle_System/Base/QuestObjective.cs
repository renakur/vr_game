using System;
using UnityEngine;


public abstract class QuestObjective : ScriptableObject
{
    public bool IsCompleted = false;
    public Action OnComplete;

    public abstract void Execute();
    public abstract void OnUpdate();

    public virtual void EndExecution()
    {
        IsCompleted = true;
        OnComplete?.Invoke();
    }

}
