using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    [SerializeField] Image portrait;
    [SerializeField] Text fullName;
    [SerializeField] Text dialogue;
    [SerializeField] Image characterNameImage;
    [SerializeField] Text characterNameText;
    [SerializeField] Image darkenImage;

    private Character character;
    public Character Character
    {
        get { return character; }
        set
        {
            character = value;
            portrait.sprite = character.portrait;
            fullName.text = character.fullName;
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
        return character != null;
    }
    public bool SpeakerIs(Character speaker)
    {
        return character == speaker;
    }
    public void Show()
    {
        gameObject.SetActive(true);
        characterNameImage.gameObject.SetActive(true);
        characterNameText.gameObject.SetActive(true);
        darkenImage.gameObject.SetActive(false);

    }
    public void Hide()
    {
        //gameObject.SetActive(false);
        characterNameImage.gameObject.SetActive(false);
        characterNameText.gameObject.SetActive(false);
        darkenImage.gameObject.SetActive(true);
    }
}
