using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace OpenAI
{
    public class ChatGPT_Edit
    {
        public delegate void ChatGPTResponseEventDelegate(string outgoingMessage);
        public event ChatGPTResponseEventDelegate OutgoingChatGPTMessageEvent;

        private OpenAIApi openai = new OpenAIApi("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");

        private List<ChatMessage> messages = new List<ChatMessage>();
        private string prompt = "Inspired by but not inluding the following word, generate a cryptic, mythical haiku using old english, up to 15 words: ";



        public async void SendReply(string inputMessage)
        {
            var newMessage = new ChatMessage()
            {
                Role = "user",

                //replace with text from whisper
                Content = prompt + inputMessage
            };

            messages.Add(newMessage);

            // Complete the instruction
            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo-0613",
                Messages = messages
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();

                messages.Add(message);
                OutgoingChatGPTMessageEvent?.Invoke(message.Content.ToString());
                //Debug.Log(message.Content.ToString());
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }
        }
    }
}
