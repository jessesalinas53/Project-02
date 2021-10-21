using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDisplay : MonoBehaviour
{
    [SerializeField] Conversation conversation;

    [SerializeField] GameObject speaker_L;
    [SerializeField] GameObject speaker_R;

    private SpeakerUI speaker_L_UI;
    private SpeakerUI speaker_R_UI;

    [SerializeField] Image dialogueBox;
    [SerializeField] Text dialogueText;

    private int activeLineIndex = 0;
    private void Start()
    {
        speaker_L_UI = speaker_L.GetComponent<SpeakerUI>();
        speaker_R_UI = speaker_R.GetComponent<SpeakerUI>();

        speaker_L_UI.Speaker = conversation.character_L;
        speaker_R_UI.Speaker = conversation.character_R;
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
        dialogueBox.gameObject.SetActive(true);

        dialogueText.gameObject.SetActive(true);

        /*
        speaker_L.gameObject.SetActive(true);
        speaker_L_UI.gameObject.SetActive(true);
        speaker_R.gameObject.SetActive(true);
        speaker_R_UI.gameObject.SetActive(true);
        */

        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speaker_L_UI.Hide();
            speaker_R_UI.Hide();
            activeLineIndex = 0;
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speaker_L_UI.SpeakerIs(character))
        {
            SetDialogue(speaker_L_UI, speaker_R_UI, line.text);
        }
        else
        {
            SetDialogue(speaker_R_UI, speaker_L_UI, line.text);
        }
    }

    void SetDialogue(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }
}
