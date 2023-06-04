using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [Header("UIs")]
    [SerializeField] private Button playBtn = null;

    private void Start()
    {
        InitBtnEvents();
    }

    private void InitBtnEvents()
    {
        playBtn.onClick.AddListener(() => { LoadingManager.instance.LoadingSlider(1); });
    }
}
