using System.Collections;
using UnityEngine;

public class PuzzleLight : MonoBehaviour
{
    [Tooltip("Add light that owns the script")]
    public Light l;

    public bool showcaseEnded { get; private set; } = false;
    public bool IsPlaying { get; private set; } = false;
   
    public void Start()
    {
        if (l != null)
        {
            l.intensity = 0.0f;
        }
    }

    public void LightShowcase()
    {
        showcaseEnded = false;
        StopAllCoroutines();
        StartCoroutine(PulseRoutine());
    }

    private IEnumerator PulseRoutine()
    {
        IsPlaying = true;
        float pulseDuration = 1.0f;

        yield return StartCoroutine(FadeLight(0.0f, 3.5f, pulseDuration)); 
        yield return StartCoroutine(FadeLight(3.5f, 0.0f, pulseDuration)); 

        
        yield return StartCoroutine(FadeLight(0.0f, 3.5f, pulseDuration)); 
        yield return StartCoroutine(FadeLight(3.5f, 0.0f, pulseDuration));

        showcaseEnded = true;
        IsPlaying = false;
    }

    
    private IEnumerator FadeLight(float startIntensity, float endIntensity, float duration)
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            l.intensity = Mathf.Lerp(startIntensity, endIntensity, timeElapsed / duration);
            yield return null; 
        }

        l.intensity = endIntensity;
    }

    
}
