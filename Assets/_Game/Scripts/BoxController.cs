using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject ballPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController.points += 1;
        Destroy(collision.gameObject);
        Instantiate(ballPrefab, new Vector3(-1f, 0.3f, -9.8f), Quaternion.identity);
    }
}
