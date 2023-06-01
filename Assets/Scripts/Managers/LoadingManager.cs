using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;
    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        else                  { Destroy(gameObject); }
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 1) // load main menu scene first, no matter the scene currently
            FirstLoad();
    }

    // handle loading bar, show progress
    [SerializeField] private Slider LoadingProgressBar = null;
    public void FirstLoad()
    {
        var loading = LoadSceneIndex(1);
        LoadingProgressBar.maxValue = 1;

        // install tween to project
        //LoadingProgressBar.value = loading.progress;
    }

    // handle loading scenes
    public AsyncOperation LoadSceneIndex(int index, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        return SceneManager.LoadSceneAsync(index, loadSceneMode);
    }

    // handle instantiate popups 
}
