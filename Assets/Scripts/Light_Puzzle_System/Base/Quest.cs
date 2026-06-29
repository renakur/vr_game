using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Objects/Quest")]
public class Quest : ScriptableObject
{
    public List<QuestObjective> Objectives = new();
    public Action OnComplete;

    private int _currentObjectiveIndex = 0;
    public void Init()
    {
        _currentObjectiveIndex = 0;

        List<QuestObjective> tmp = new List<QuestObjective>();
        foreach (QuestObjective objective in Objectives)
            tmp.Add(Instantiate(objective));

        Objectives = tmp;

        /* foreach (QuestObjective questObjective in Objectives)
         {
             questObjective.Execute();
             questObjective.OnComplete += OnQuestObjectiveCompleted;
         }*/

        if (Objectives.Count > 0)
        {
            ActivateObjective(_currentObjectiveIndex);
        }
    }
    private void ActivateObjective(int index)
    {
        if (index < Objectives.Count)
        {
            
            Objectives[index].OnComplete += OnQuestObjectiveCompleted;
            Objectives[index].Execute();
            
        }
        else
        {
            
            OnComplete?.Invoke();
        }
    }

    private void OnQuestObjectiveCompleted()
    {
        /* foreach (QuestObjective questObjective in Objectives)
             if (!questObjective.IsCompleted)
                 return;

         foreach (QuestObjective questObjective in Objectives)
             questObjective.OnComplete -= OnQuestObjectiveCompleted;

         OnComplete?.Invoke();*/

        Objectives[_currentObjectiveIndex].OnComplete -= OnQuestObjectiveCompleted;
        _currentObjectiveIndex++;
        ActivateObjective(_currentObjectiveIndex);
    }

    public void Update()
    {
        /* foreach (QuestObjective objective in Objectives)
         {
             objective.OnUpdate();
         }*/

        if (_currentObjectiveIndex < Objectives.Count)
        {
            Objectives[_currentObjectiveIndex].OnUpdate();
        }
    }
}
