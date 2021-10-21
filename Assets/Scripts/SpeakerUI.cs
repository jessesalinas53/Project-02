using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    [SerializeField] Image portrait;
    [SerializeField] Text fullName;
    [SerializeField] Text dialogue;
    [SerializeField] Image speakerNameImage;
    [SerializeField] Text speakerNameText;
    [SerializeField] Image darkenPortrait;
    [SerializeField] Image darkenName;

    private Character speaker;
    public Character Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            fullName.text = speaker.fullName;
        }
    }
    public string Dialogue
    {
        set
        {
            dialogue.text = value;
        }
    }
    public bool HasSpeaker()
    {
        return speaker != null;
    }
    public bool SpeakerIs(Character speaker)
    {
        return this.speaker == speaker;
    }
    public void Show()
    {
        gameObject.SetActive(true);
        speakerNameImage.gameObject.SetActive(true);
        speakerNameText.gameObject.SetActive(true);
        darkenPortrait.gameObject.SetActive(false);
        darkenName.gameObject.SetActive(false);

    }
    public void Hide()
    {
        //gameObject.SetActive(false);
        //speakerNameImage.gameObject.SetActive(false);
        //speakerNameText.gameObject.SetActive(false);
        darkenPortrait.gameObject.SetActive(true);
        darkenName.gameObject.SetActive(true);
    }
}
