using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class CharacterSelector : MonoBehaviour
{
    [Header("UIs")]
    [SerializeField] private Image characterSprite = null;
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private TMP_Text descText = null;

    [Header("Datas")]
    [SerializeField] private int characterIndex = 0;

    private void OnEnable()
    {
        var characterProfile = DataManager.instance.CharacterProfiles[characterIndex];
        characterSprite.sprite = characterProfile.Sprite;
        nameText.text = characterProfile.Name;
        descText.text = characterProfile.Description;
    }
}
