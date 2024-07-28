using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] LoaderManager loaderManager;
    [SerializeField] Image LoadBar;
    [SerializeField] float fill;

    private void Update()
    {
        fill = loaderManager.loadingProgress;
        LoadBar.fillAmount = fill;
    }
}
