using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject ballPrefab;
    public void SpawnBall(GameObject ball)
    {
        Instantiate(ballPrefab, new Vector3(-1f, 0.3f, -9.8f), Quaternion.identity);
    }
}
