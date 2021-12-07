using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        GameManager.Instance.OnBallEnteredBox += OnBallEnteredBox;
    }

    private void OnBallEnteredBox()
    {
        text.text = $"Punkty: {GameManager.Instance.points}";
    }
}
