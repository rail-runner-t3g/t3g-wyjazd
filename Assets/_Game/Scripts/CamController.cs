using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [HideInInspector] public float xAxis;
    [HideInInspector] public float yAxis;
    public float sensitivity = 1f;
    public bool invert = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        yAxis = Input.GetAxis("Mouse X") * sensitivity;
        xAxis = Input.GetAxis("Mouse Y") * sensitivity;
        transform.eulerAngles = transform.eulerAngles + new Vector3(invert ? xAxis : -xAxis, yAxis, 0f);
    }
}
