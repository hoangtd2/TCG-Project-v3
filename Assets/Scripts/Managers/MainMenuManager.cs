using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public enum CanvasState { Main, CharaSelect }

    [Header("Buttons")]
    [SerializeField] private Button playBtn = null;
    [SerializeField] private Button selectCharacterBtn = null;

    [Header("Images")]
    [SerializeField] private Image characterSprite = null;

    [Header("GameObjects")]
    [SerializeField] private GameObject mainMenuPanel = null;
    [SerializeField] private GameObject selectCharacterPanel = null;

    private void Start()
    {
        ChangeCanvasState(CanvasState.Main);
        InitBtnEvents();
        InitCharacterUIs();
    }

    private void InitBtnEvents()
    {
        playBtn.onClick.AddListener(() => { LoadingManager.instance.LoadingSlider("Gameplay"); });
        selectCharacterBtn.onClick.AddListener(() => { ChangeCanvasState(CanvasState.CharaSelect); });
    }

    private void InitCharacterUIs()
    {
        var characterProfile = DataManager.instance.CharacterProfiles[PlayerPrefs.GetInt("DefaultCharacter", 0)];
        characterSprite.overrideSprite = characterProfile.Sprite;
    }

    public void ChangeCanvasState(CanvasState state)
    {
        mainMenuPanel.SetActive(state == CanvasState.Main);
        selectCharacterPanel.SetActive(state == CanvasState.CharaSelect);
    }
    public void ChangeCharacter(int index = -1)
    {
        ChangeCanvasState(CanvasState.Main);

        PlayerPrefs.SetInt("DefaultCharacter", index);
        InitCharacterUIs();
    }
}
