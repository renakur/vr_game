using UnityEngine;

[CreateAssetMenu(fileName = "CorrectCode_SO", menuName = "Scriptable Objects/CorrectCode_SO")]
public class CorrectCode_SO : ScriptableObject
{
    [Tooltip("the code must always be from 1st to last digit ")]
    public int[] digits;
}
