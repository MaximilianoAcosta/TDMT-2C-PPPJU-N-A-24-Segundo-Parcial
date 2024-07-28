using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void ChangeGameScene(string scene)
    {
        Debug.Log(SceneManager.GetActiveScene().name + "unload");
        LoaderManager.Get().LoadScene(scene);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LockCursorOnSceneChange(bool lockCursor)
    {
        if (lockCursor) { Cursor.lockState = CursorLockMode.Locked; }
        else { Cursor.lockState = CursorLockMode.None; }
    }
}
