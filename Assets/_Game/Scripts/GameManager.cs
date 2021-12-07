using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityAction OnBallEnteredBox;
    public Transform spawnPoint;
    public bool cameraLocked = false;
    public int points;
    public int lifeAmout = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else {
            Debug.LogError("There is already a game manager.");
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (lifeAmout < 0)
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int amount)
    {
        points += amount;
        OnBallEnteredBox.Invoke();
    }
}
