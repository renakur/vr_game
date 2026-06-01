using System.Collections;
using UnityEngine;

public class PuzzleLight : MonoBehaviour
{
    [Tooltip("Add light that owns the script")]
    public Light l;

    public void Start()
    {
        if (l != null)
        {
            l.intensity = 0.0f;
        }
    }

    public void LightShowcase()
    {
        StopAllCoroutines();
        StartCoroutine(PulseRoutine());
    }

    private IEnumerator PulseRoutine()
    {
        float pulseDuration = 1.0f;

        yield return StartCoroutine(FadeLight(0.0f, 3.5f, pulseDuration)); 
        yield return StartCoroutine(FadeLight(3.5f, 0.0f, pulseDuration)); 

        
        yield return StartCoroutine(FadeLight(0.0f, 3.5f, pulseDuration)); 
        yield return StartCoroutine(FadeLight(3.5f, 0.0f, pulseDuration)); 
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
