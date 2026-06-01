using UnityEngine;

public class ExecuteQuest : MonoBehaviour
{
    public Quest questToStart;

    private void Start()
    {
        questToStart = Instantiate(questToStart);
        questToStart.Init();
        questToStart.OnComplete += OnComplete;
    }

    private void Update()
    {
        questToStart.Update();
    }

    private void OnComplete()
    {
        questToStart.OnComplete -= OnComplete;
    }
}
