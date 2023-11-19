using UnityEngine;
using TMPro;

public class ClearInputField : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    public void ClearText()
    {
        _inputField.text = ""; // Clear the text
    }
}