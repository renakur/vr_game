using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LightCatcher;

public class SequenceManager : MonoBehaviour
{
    public static SequenceManager Instance { get; private set; }

    private List<LightColors> currentSequence = new List<LightColors>();
    private int playerInputIndex = 0;

    public bool isShowcaseRunning { get; private set; } = false;
    public bool isPuzzleCompleted { get; private set; } = false;

    private const float LIGHT_ANIMATION_DURATION = 4.0f;
    private const float DELAY_BETWEEN_LIGHTS = 0.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(gameObject); return; 
        }

        Instance = this;
    }

    public void StartPuzzle(List<LightColors> sequenceToFollow)
    {
        currentSequence = sequenceToFollow;
        playerInputIndex = 0;
        isPuzzleCompleted = false;

        StartCoroutine(PlayShowcaseRoutine());
    }

    private IEnumerator PlayShowcaseRoutine()
    {
        isShowcaseRunning = true;
        LightCatcher.Instance.ResetAllButtons();

        yield return new WaitForSeconds(4.0f);

        foreach (LightColors color in currentSequence)
        {
            LightCatcher.Instance.TurnOnLight(color);

            yield return new WaitForSeconds(LIGHT_ANIMATION_DURATION + DELAY_BETWEEN_LIGHTS);
        }

        isShowcaseRunning = false;
       
    }

    public void OnButtonDetailsPressed(LightColors pressedColor)
    {
        if (isShowcaseRunning || isPuzzleCompleted) return;

        if (pressedColor == currentSequence[playerInputIndex])
        {
            playerInputIndex++;

            if (playerInputIndex >= currentSequence.Count)
            {
                isPuzzleCompleted = true;
            }
        }
        else
        {
            ResetAndRestartPuzzle();
        }
    }

    private void ResetAndRestartPuzzle()
    {
        
        playerInputIndex = 0;
        StartCoroutine(ErrorAndRestartRoutine());

    }

    private IEnumerator ErrorAndRestartRoutine()
    {
        isShowcaseRunning = true;

        LightCatcher.Instance.TurnOnLight(LightColors.red);

        yield return new WaitForSeconds(LIGHT_ANIMATION_DURATION + 1.0f);

        StartCoroutine(PlayShowcaseRoutine());
    }
}
