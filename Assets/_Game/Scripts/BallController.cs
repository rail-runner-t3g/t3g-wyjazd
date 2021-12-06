using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Material NormalMaterial;
    public Material SelectedMaterial;
    public Renderer MeshRenderer;

    public void Highlight(bool highlighted)
    {
        MeshRenderer.material = highlighted ? SelectedMaterial : NormalMaterial;
    }
}
