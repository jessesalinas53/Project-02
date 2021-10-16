using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField] Text _dialogueTextUI;
    [SerializeField] Text _chacterNameTextUI;
    [SerializeField] Image _characterPortraitUI;

    public void Display(DialogueData data)
    {
        _dialogueTextUI.text = data.Dialogue;
        _chacterNameTextUI.text = data.CharacterName;
        _characterPortraitUI.sprite = data.Portrait;
    }
}
