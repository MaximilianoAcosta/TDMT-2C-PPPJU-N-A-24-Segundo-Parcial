using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneChangeColider : MonoBehaviour
{
    [SerializeField] string collideWithTag;
    [SerializeField] string sceneToChange;

    [SerializeField] SceneController sceneController;
    [SerializeField] PauseGame PauseGame;
    [SerializeField] MenuActivation MenuActivation;
    SaveValueManager SaveValueManager;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(collideWithTag))
        {
            ChangeLevel();
        }
    }
    [ContextMenu("ChangeLevel")]
    private void ChangeLevel()
    {
        PauseGame.Pause();
        SaveValueManager = GetComponent<SaveValueManager>();
        SaveValueManager.SaveDataActualValues();
        MenuActivation.OpenMenu(1);
        sceneController.ChangeGameScene(sceneToChange);
    }
}