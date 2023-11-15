using OpenAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatGPT_SendMessage : MonoBehaviour
{
    private ChatGPT_Edit _chatGPT;
    private PoemManager _poemManager;

    [SerializeField] private GameObject obj;
    [SerializeField] private TMP_InputField _inputField;

    // Start is called before the first frame update
    void Start()
    {
        _chatGPT = new ChatGPT_Edit();
        _poemManager = FindObjectOfType<PoemManager>();
        _chatGPT.OutgoingChatGPTMessageEvent += OnChatGPTResponse;
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

        // Create a new Poem object
        Poem newPoem = new Poem();
        newPoem.Text = chatGPT_message;

        _poemManager.AssignPoemToGameObject(obj, newPoem);
    }
}
