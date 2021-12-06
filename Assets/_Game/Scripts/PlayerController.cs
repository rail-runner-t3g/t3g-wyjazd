using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BallController highlightedBall;
    void Update()
    {
        bool hit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hitObject, 100f);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.blue);

        if (hit)
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
    }
}
