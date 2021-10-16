using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    [SerializeField] Conversation conversation;

    [SerializeField] GameObject character_L;
    [SerializeField] GameObject character_R;

    private SpeakerUI character_L_UI;
    private SpeakerUI character_R_UI;

    private int activeLineIndex = 0;
    private void Start()
    {
        character_L_UI = character_L.GetComponent<SpeakerUI>();
        character_R_UI = character_R.GetComponent<SpeakerUI>();

        character_L_UI.Character = conversation.character_L;
        character_R_UI.Character = conversation.character_R;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }

    void AdvanceConversation()
    {
        if(activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            character_L_UI.Hide();
            character_R_UI.Hide();
            activeLineIndex = 0;
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (character_L_UI.SpeakerIs(character))
        {
            SetDialogue(character_L_UI, character_R_UI, line.text);
        }
        else
        {
            SetDialogue(character_R_UI, character_L_UI, line.text);
        }
    }

    void SetDialogue(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }
}
