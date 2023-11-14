using OpenAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatGPT_SendMessage : MonoBehaviour
{
    private ChatGPT_Edit _chatGPT;

    // Start is called before the first frame update
    void Start()
    {
        _chatGPT = new ChatGPT_Edit();
        _chatGPT.OutgoingChatGPTMessageEvent += OnChatGPTResponse;
    }

    public void sendChatGPTMessage(string message)
    {
        _chatGPT.SendReply(message);
    }

    private void OnChatGPTResponse(string chatGPT_message)
    {
        Debug.Log(chatGPT_message);
    }
}
