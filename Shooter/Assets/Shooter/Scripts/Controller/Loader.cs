using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : Singleton<Loader>
{
    public static Loader LocalInstance;

    public event Action OnLoadingCompleteSceneEvent;

    public event Action OnBeforeLoadingSceneEvent;

    public List<GameObject> ListObjectsLoadedAtStart = new List<GameObject>();
    public Image ProgressBar;
    public UnityEvent FinalActions;

    private int loadingStep;

    #region StartLoader

    private void Start()
    {
        if (LocalInstance != null && LocalInstance != this)
            Destroy(gameObject);

        LocalInstance = this;
        Debug.Log("Loader: Start");
        DontDestroyOnLoad(gameObject);
        loadingStep = -1;
        NextStepLoadStep();
    }

    public void NextStepLoadStep()
    {
        loadingStep++;
        ChangeProgressBar(loadingStep, ListObjectsLoadedAtStart.Count);

        if (loadingStep < ListObjectsLoadedAtStart.Count)
        {
            Instantiate(ListObjectsLoadedAtStart[loadingStep], transform);

            NextStepLoadStep();
        }
        else
        {
            FinalActions?.Invoke();
        }
    }

    public void ChangeProgressBar(int currentStep, int endStep)
    {
        if (ProgressBar != null)
            ProgressBar.fillAmount = (float)currentStep / (float)endStep;
    }

    #endregion StartLoader

    public void LoadScene(string _sceneName)
    {
        StartCoroutine(LoadingScene(_sceneName));
    }

    private IEnumerator LoadingScene(string sceneName)
    {
        if (ProgressBar != null)
            ProgressBar.fillAmount = 0f;

        OnBeforeLoadingSceneEvent?.Invoke();

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (async.progress < 0.89)
        {
            if (ProgressBar != null)
            {
                ProgressBar.fillAmount = async.progress;
                yield return null;
            }
        }

        if (ProgressBar != null)
            ProgressBar.fillAmount = 1f;

        OnLoadingCompleteSceneEvent?.Invoke();
        yield return null;
    }
}