using UnityEngine;

public static class Bootstrapper
{
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        
        GameObject audioManagerPrefab = Resources.Load<GameObject>("Audio_GrabManager");

        if (audioManagerPrefab != null)
        {
            
            GameObject.Instantiate(audioManagerPrefab);
            
        }
        else
        {
            Debug.LogError("Не удалось найти префаб 'Audio_Manager' в папке Resources! Проверь название.");
        }
    }
}