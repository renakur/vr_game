using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public PuzzleLight targetLight;
    public LightColors myColor;
    public bool wasLightPressed { get; private set; } = false;
    
    private void OnTriggerEnter(Collider other)
    {
        PressButton();
    }
    public void PressButton()
    {
        if (SequenceManager.Instance != null && SequenceManager.Instance.isShowcaseRunning)
            return;

        if (LightCatcher.Instance != null && LightCatcher.Instance.IsAnyLightPlaying())
            return;

        if (targetLight != null)
        {
            targetLight.LightShowcase();
            wasLightPressed = true;

            if (SequenceManager.Instance != null)
            {
                SequenceManager.Instance.OnButtonDetailsPressed(myColor);
            }
        }
    }

    public void ResetButton()
    {
        wasLightPressed = false;
    }
}
