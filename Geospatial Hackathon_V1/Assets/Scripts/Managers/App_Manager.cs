using OpenAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class App_Manager : MonoBehaviour
{
    private ChatGPT_Edit _chatGPT;
    private PoemManager _poemManager;
    private string lastClickedObjectName;

    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _objName, _poemTextObj;
    [SerializeField] private GameObject UIObject;

    // Start is called before the first frame update
    void Start()
    {
        _chatGPT = new ChatGPT_Edit();
        _poemManager = FindObjectOfType<PoemManager>();

        _chatGPT.OutgoingChatGPTMessageEvent += OnChatGPTResponse;
        ClickablePoemObject.OnObjectClicked += HandleObjectClicked;
    }

    public void sendChatGPTMessage()
    {
        if(_inputField.text != null)
        {
            _chatGPT.SendReply(_inputField.text);
            Debug.Log(_inputField.text);
        }
    }

    private void OnChatGPTResponse(string chatGPT_message)
    {
        Debug.Log(chatGPT_message);

        Poem newPoem = new Poem();
        newPoem.Text = chatGPT_message;

        GameObject targetObject = GameObject.Find(lastClickedObjectName);
        if (targetObject != null)
        {
            _poemManager.AssignPoemToGameObject(targetObject, newPoem);

            if (_poemTextObj != null)
            {
                _poemTextObj.text = chatGPT_message;
            }
            else
            {
                Debug.LogError("PoemText component not found.");
            }
        }
        else
        {
            Debug.LogError("Object with unique name not found: " + lastClickedObjectName);
        }
    }

    private void HandleObjectClicked(string uniqueName)
    {
        Debug.Log("Clicked object with unique name: " + uniqueName);
        lastClickedObjectName = uniqueName;
        UIObject.SetActive(true); // Activate the UI when an object is clicked

        // Check if there's an existing poem for this object
        Poem existingPoem = _poemManager.GetPoemFromGameObject(GameObject.Find(uniqueName));

        if (existingPoem != null && !string.IsNullOrEmpty(existingPoem.Text))
        {
            // If there's an existing poem, display it
            _objName.text = uniqueName;
            _poemTextObj.text = existingPoem.Text;
        }
        else
        {
            // If there's no poem, prompt for input
            _objName.text = uniqueName;
            _poemTextObj.text = "Input a word to create a poem";
        }
    }

    private void OnDisable()
    {
        _chatGPT.OutgoingChatGPTMessageEvent -= OnChatGPTResponse;
        ClickablePoemObject.OnObjectClicked -= HandleObjectClicked;
    }
}
