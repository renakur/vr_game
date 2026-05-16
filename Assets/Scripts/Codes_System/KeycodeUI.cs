using UnityEngine;

public class KeycodeUI : MonoBehaviour
{
    public TMPro.TMP_Text text;
    public KeycodeValidator validator;
    public static KeycodeUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void CorrectResults()
    { 
        text.text = "CODE CORRECT";
        text.color = Color.green;
    }

    public void IncorrectResults()
    {
        text.text = "CODE INCORRECT";
        text.color = Color.red;
    }

    public void ResetResults()
    {
        text.text = " ";
        text.color = Color.white;
    }

    public void DisplayCode()
    {
        string currentText = "";

        
        for (int i = 0; i < validator.currentIndex; i++)
        {
            currentText += validator.currentCode[i].ToString();
        }

        text.text = currentText;
    }
}

    

