using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public Canvas guiCanvas;
    public Canvas pauseCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            guiCanvas.enabled = guiCanvas.enabled == true ? false : true;
            pauseCanvas.enabled = pauseCanvas.enabled == true ? false : true;
        }

        if (pauseCanvas.enabled == true && !GameManager.Instance.cameraLocked)
        {
            GameManager.Instance.cameraLocked = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (pauseCanvas.enabled == false && GameManager.Instance.cameraLocked)
        {
            GameManager.Instance.cameraLocked = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameManager.Instance.Restart();
    }
}
