using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    void Update()
    {
        RaycastHit hitObject;
        bool hit = Physics.Raycast(transform.position, transform.forward, out hitObject, 100f);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.blue);
    }
}
