using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;
    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
        else                  { Destroy(gameObject); }
    }

    private void OnDisable()
    {
        DOTween.Kill(gameObject);
    }

    [Header("Loading")]
    [SerializeField] private List<CanvasGroup> backgrounds = new List<CanvasGroup>();
    private int backgroundIndexInUse;

    [Header("Fade")]
    [SerializeField] private float fadeInTime = 0.3f;
    [SerializeField] private float fadeOutTime = 0.5f;
    [SerializeField] private AnimationCurve fadeCurve = null;

    [Header("Slider")]
    [SerializeField] private Slider LoadingProgressBar = null;

    #region Loading Animations
    private IEnumerator FadeInBackground(bool skipAnimation = false)
    {
        // if input larger index than available will use last background
        backgroundIndexInUse = Random.Range(0, backgrounds.Count);

        if (!skipAnimation)
        {
            bool finishAnimation = false;
            DOTween.Sequence()
                .Append(backgrounds[backgroundIndexInUse].DOFade(1, fadeInTime))
                .SetEase(fadeCurve)
                .SetId(gameObject)
                .OnComplete(() => {
                    finishAnimation = true;
                });
            yield return new WaitUntil(() => finishAnimation);
        }

        yield return new WaitForSeconds(0.2f);
    }
    private IEnumerator FadeOutBackground(bool skipAnimation = false)
    {
        if (!skipAnimation)
        {
            bool finishAnimation = false;
            DOTween.Sequence()
                .Append(backgrounds[backgroundIndexInUse].DOFade(0, fadeOutTime))
                .SetEase(fadeCurve)
                .SetId(gameObject)
                .OnComplete(() => {
                    finishAnimation = true;
                });
            yield return new WaitUntil(() => finishAnimation);
        }

        yield return new WaitForSeconds(0.2f);
    }
    private IEnumerator IELoadingSlider(int index, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        yield return FadeInBackground();

        LoadingProgressBar.maxValue = 1;
        var loadingOperation = LoadSceneIndex(index, loadSceneMode);
        yield return new WaitUntil(() =>
        {
            LoadingProgressBar.value = loadingOperation.progress;
            return loadingOperation.isDone;
        });
        yield return new WaitForSeconds(0.2f);

        yield return FadeOutBackground();
    }
    private IEnumerator IELoadingFade(int index, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        yield return FadeInBackground();

        var loadingOperation = LoadSceneIndex(index, loadSceneMode);
        yield return new WaitUntil(() => loadingOperation.isDone);

        yield return FadeOutBackground();
    }
    #endregion

    #region Loading Calls
    public void LoadingSlider(int index) // for buttons
    {
        StartCoroutine(IELoadingSlider(index));
    }
    public void LoadingSlider(int index, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(IELoadingSlider(index, loadSceneMode));
    }
    public void LoadingFade(int index) // for buttons
    {
        StartCoroutine(IELoadingFade(index));
    }
    public void LoadingFade(int index, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(IELoadingFade(index, loadSceneMode));
    }
    #endregion

    #region Load Functions
    public AsyncOperation LoadSceneIndex(int index, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        return SceneManager.LoadSceneAsync(index, loadSceneMode);
    }
    #endregion

    // handle instantiate popups 
}
