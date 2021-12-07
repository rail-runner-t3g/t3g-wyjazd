using UnityEngine;

public class BallController : MonoBehaviour
{
    public Material normalMaterial;
    public Material selectedMaterial;
    public Renderer meshRenderer;
#pragma warning disable CS0109 // Sk³adowa nie ukrywa dziedziczonej sk³adowej; s³owo kluczowe new nie jest wymagane
    public new Rigidbody rigidbody;
#pragma warning restore CS0109 // Sk³adowa nie ukrywa dziedziczonej sk³adowej; s³owo kluczowe new nie jest wymagane
    public GameObject ballPrefab;

    public void Highlight(bool highlighted)
    {
        meshRenderer.material = highlighted ? selectedMaterial : normalMaterial;
    }

    public void Throw(float force, Vector3 throwVector)
    {
        transform.SetParent(null);
        rigidbody.isKinematic = false;
        rigidbody.AddForce(throwVector * force, ForceMode.Impulse);
        transform.tag = "ThrownBall";
    }

    public void Terminate()
    {
        if (GameManager.Instance.points != 0)
        {
            GameManager.Instance.lifeAmout -= 1;
        }
        Destroy(gameObject);
    }
}
