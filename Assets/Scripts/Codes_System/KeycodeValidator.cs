using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class KeycodeValidator : MonoBehaviour
{
    public CorrectCode_SO codeSO;
    public int[] currentCode;
    private int[] correctCode;
    public int currentIndex = 0;
    public bool isCorrect = true;
    private bool isLocked;

    [SerializeField] private UnityEvent<int[]> codeCorrect;
    [SerializeField] private UnityEvent<int[]> codeIncorrect;
    [SerializeField] private UnityEvent<int[]> displayCode;
    public static KeycodeValidator Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        correctCode = codeSO.digits;
        currentCode = new int[codeSO.digits.Length];
    }

    public void AddDigit(int digit)
    {
        if (isLocked) return;
        if (currentIndex >= currentCode.Length) return;

        currentCode[currentIndex] = digit;
        currentIndex++;

        displayCode?.Invoke(currentCode);
        
        if (currentIndex == correctCode.Length)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        isCorrect = true;

        for (int i = 0; i < currentCode.Length; i++)
        {
            if (currentCode[i] != correctCode[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            codeCorrect?.Invoke(currentCode);
        }
        else
        {
            codeIncorrect?.Invoke(currentCode);
            Clear();
        }
    }

    private void Clear()
    {
        isLocked = true;
        currentIndex = 0;
        currentCode = new int[correctCode.Length];
    
        StartCoroutine(Reset());
    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(2f);

        KeycodeUI.Instance.ResetResults();
        displayCode?.Invoke(currentCode);

        isLocked = false;
    }
}
