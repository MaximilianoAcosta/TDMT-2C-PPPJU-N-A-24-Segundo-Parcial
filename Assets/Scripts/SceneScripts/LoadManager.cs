using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderManager : MonoBehaviour
{
    private static LoaderManager instance;

    public float loadingProgress;
    public float timeLoading;
    public float fakeLoadTime = 5;

    public static event Action<LoaderManager> OnLoadingStart;
    public static event Action<LoaderManager> OnLoadingEnd;

    public static LoaderManager Get()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void LoadScene(string sceneName)
    {

        StartCoroutine(AsynchronousLoadWithFake(sceneName, fakeLoadTime));
        
    }

    IEnumerator AsynchronousLoadWithFake(string scene, float fakeTime)
    {
        OnLoadingStart?.Invoke(this);

        loadingProgress = 0;
        timeLoading = 0;
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            timeLoading += Time.unscaledDeltaTime;
            
            loadingProgress = ao.progress + 0.1f;
            loadingProgress = loadingProgress * timeLoading / fakeTime;
  
            if (loadingProgress >= 1)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
        OnLoadingEnd?.Invoke(this);
    }
}
