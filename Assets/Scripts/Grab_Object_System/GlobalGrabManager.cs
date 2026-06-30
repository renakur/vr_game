using UnityEngine;
using Valve.VR.InteractionSystem;
using FMODUnity;

public class GlobalGrabManager : MonoBehaviour
{
    [Header("dfsfsf")]
    public EventReference universalPickupSound;

    void Start()
    {
        
        Interactable[] allInteractables = FindObjectsByType<Interactable>(FindObjectsSortMode.None);

        int count = 0;

        
        foreach (Interactable item in allInteractables)
        {
            // Проверяем: вдруг ты на этот конкретный предмет уже повесила уникальный звук вручную
            if (item.GetComponent<GrabSound>() == null)
            {
                // 3. Автоматически вешаем скрипт GrabSound через код!
                GrabSound newSoundScript = item.gameObject.AddComponent<GrabSound>();

                // 4. Передаем ему наш универсальный звук
                newSoundScript.pickupSound = universalPickupSound;
                count++;
            }
        }

        
        Debug.Log($"=== [MANAGER] sound added on {count} items ===");
    }
}