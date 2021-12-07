using UnityEngine;

public class BoxController : MonoBehaviour
{
    private BallController currentBall;
    public GameObject ballPrefab;
    public Box boxData;

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.AddScore(boxData.points);
        collision.gameObject.tag = "Ball";
        collision.rigidbody.isKinematic = true;
        collision.transform.position = GameManager.Instance.spawnPoint.position;
    }
}
