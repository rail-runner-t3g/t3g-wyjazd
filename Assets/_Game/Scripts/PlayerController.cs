using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static int points = 0;
    private BallController highlightedBall;
    public Transform grabParent;
    private BallController grabbedBall;
    public TextMeshProUGUI text;
    private BallController lastBall;
    public Slider powerSlider;
    private float throwForce;

    void Update()
    {
        text.text = $"Punkty: {points}";
        RaycastHit hitObject;
        bool hit = Physics.Raycast(transform.position, transform.forward, out hitObject, 100f);
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.blue);

        if (hit && grabbedBall == null && hitObject.transform.CompareTag("Ball"))
        {
            BallController ballController = hitObject.transform.GetComponent<BallController>();

            if (ballController != null && ballController != highlightedBall)
            {
                if (highlightedBall != null)
                    highlightedBall.Highlight(false);

                highlightedBall = ballController;
                highlightedBall.Highlight(true);
            }
            else if (ballController == null && highlightedBall != null)
            {
                highlightedBall.Highlight(false);
                highlightedBall = null;
            }
        } else if (!hit || !hitObject.transform.CompareTag("Ball")) 
        {
            if (highlightedBall != null)
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

        else if (grabbedBall != null)
        {
            if (Input.GetButton("Fire1"))
            {
                if (throwForce <= 30f)
                {
                    throwForce += Time.fixedDeltaTime * 4.5f;
                } else
                {
                    throwForce = 30;
                }
                
            }

            if (!Input.GetButton("Fire1") && throwForce >= 1f)
            {
                grabbedBall.Throw(throwForce, transform.forward);
                lastBall = grabbedBall;
                grabbedBall = null;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                throwForce = 0f;
            }
        }

        powerSlider.value = throwForce;

        if (lastBall != null && lastBall.transform.position.y <= -4)
        {
            lastBall.Terminate();
            lastBall.tag = "Ball";
            lastBall.rigidbody.isKinematic = true;
            Instantiate(lastBall.gameObject, new Vector3(-1f, 0.3f, -9.8f), Quaternion.identity);
            lastBall = null;
        }
    }
}
