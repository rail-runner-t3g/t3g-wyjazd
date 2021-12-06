using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static int points = 0;
    private BallController highlightedBall;
    public Transform grabParent;
    private BallController grabbedBall;
    public float throwForce = 100f;
    public TextField text;
    void Update()
    {
        text.text = $"Punkty: {points}";
        bool hit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hitObject, 100f);
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.blue);

        if (hit && highlightedBall == null)
        {
            BallController ballController = hitObject.transform.GetComponent<BallController>();
            if (ballController != null && ballController != highlightedBall)
            {
                if (highlightedBall != null) highlightedBall.Highlight(false);    
                highlightedBall = ballController;
                highlightedBall.Highlight(true);
            } 
            else if (ballController == null && highlightedBall != null)
            {
                highlightedBall.Highlight(false);
                highlightedBall = null;
            }
        }

        if (highlightedBall != null && grabbedBall == null && Input.GetButtonDown("Fire1"))
        {
            highlightedBall.transform.SetParent(grabParent);
            highlightedBall.transform.localPosition = Vector3.zero;
            grabbedBall = highlightedBall;
            grabbedBall.Highlight(false);
            highlightedBall = null;
        }
        else if (grabbedBall != null && Input.GetButtonDown("Fire1"))
        {
            grabbedBall.Throw(throwForce, transform.forward);
            grabbedBall = null;
        }
    }
}
