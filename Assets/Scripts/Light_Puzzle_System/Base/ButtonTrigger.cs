using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public PuzzleLight targetLight;

    private void OnTriggerEnter(Collider other)
    {
        if (targetLight != null)
        {
            targetLight.LightShowcase();
        }
    }
}
