using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuestionEvent : UnityEvent<Question> {}

public class ConversationController : MonoBehaviour
{
    public Conversation conversation;
    public QuestionEvent questionEvent;

    public GameObject character_L;
    public GameObject character_R;

    private SpeakerUI speakerUI_L;
    private SpeakerUI speakerUI_R;

    private int activeLineIndex;
    private bool conversationStarted = false;

    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    private void Start()
    {
        speakerUI_L = character_L.GetComponent<SpeakerUI>();
        speakerUI_R = character_R.GetComponent<SpeakerUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            AdvanceLine();
        else if (Input.GetKeyDown(KeyCode.Escape))
            EndConversation();
    }

    private void EndConversation()
    {
        conversation = null;
        conversationStarted = false;
        speakerUI_L.Hide();
        speakerUI_R.Hide();
    }

    private void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUI_L.Character = conversation.character_L;
        speakerUI_R.Character = conversation.character_R;
    }

    private void AdvanceLine()
    {
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.lines.Length)
            DisplayLine();
        else
            AdvanceConversation();
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUI_L.SpeakerIs(character))
        {
            SetDialogue(speakerUI_L, speakerUI_R, line.text);
        }
        else
        {
            SetDialogue(speakerUI_R, speakerUI_L, line.text);
        }

        activeLineIndex += 1;
    }

    private void AdvanceConversation()
    {
        if (conversation.question != null)
            questionEvent.Invoke(conversation.question);
        else if (conversation.nextConversation != null)
            ChangeConversation(conversation.nextConversation);
        else
            EndConversation();
    }

    private void SetDialogue(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }
}
