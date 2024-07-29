using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] HealthController healthController;
    private bool paused = false;
    private ThirdPersonController ThirdPersonController;

    private void Start()
    {
        healthController = GetComponent<HealthController>();
        ThirdPersonController = GetComponent<ThirdPersonController>();
        Time.timeScale = 1;
        if (paused)
        {
            Resume();
        }
    }
    public void OnPausePressed(InputValue value)
    {
        if (value.isPressed && !paused)
        {
            Pause();
        }
        else if (value.isPressed && paused && healthController.alive)
        {
            Resume();
        }
    }



    public void Pause()
    {
        ThirdPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

    }

    public void Resume()
    {
        ThirdPersonController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }
}
