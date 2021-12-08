using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public Canvas guiCanvas;
    public Canvas pauseCanvas;
    public Canvas deathCanvas;
    public CamController cam;
    private MonoBehaviour camScript;

    private void Start()
    {
        if (camScript == null) camScript = cam.GetComponent<CamController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (deathCanvas.enabled)
            {
                return;
            }
            guiCanvas.enabled = guiCanvas.enabled != true;
            pauseCanvas.enabled = pauseCanvas.enabled != true;
        }

        if (pauseCanvas.enabled == true && camScript.enabled)
        {
            camScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }

        if (pauseCanvas.enabled == false && camScript.enabled == false)
        {
            camScript.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }


        if (GameManager.Instance.lifeAmout < 0 && !deathCanvas.enabled)
        {
            guiCanvas.enabled = guiCanvas.enabled != true;
            deathCanvas.enabled = deathCanvas.enabled == false;
            camScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
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
