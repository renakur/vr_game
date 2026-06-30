using UnityEngine;
using FMODUnity;

public class AmbientAudioManager : MonoBehaviour
{
    public static AmbientAudioManager instance;

    [Header("Настройки FMOD")]
    public EventReference ambientEvent;
    private FMOD.Studio.EventInstance ambientInstance;

    void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
        if (!ambientEvent.IsNull)
        {
            ambientInstance = RuntimeManager.CreateInstance(ambientEvent);
            ambientInstance.start();

            
            ambientInstance.release();
        }
        else
        {
            Debug.LogWarning("не назначен ивент референс");
        }
    }

    void OnDestroy()
    {
        if (instance == this)
        {
            ambientInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}