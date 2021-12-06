using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Material normalMaterial;
    public Material selectedMaterial;
    public Renderer meshRenderer;
    public Rigidbody rigidbody;

    public void Highlight(bool highlighted)
    {
        meshRenderer.material = highlighted ? selectedMaterial : normalMaterial;
    }

    public void Throw(float force, Vector3 throwVector)
    {
        transform.SetParent(null);
        rigidbody.isKinematic = false;
        rigidbody.AddForce(throwVector * force, ForceMode.Impulse);
    }
}
