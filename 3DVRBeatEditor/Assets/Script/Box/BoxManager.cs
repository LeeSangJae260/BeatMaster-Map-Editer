using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public Material afterPassing;
    public Material beforePassing;

    public MeshRenderer render;
    public BoxCollider boxCollider;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayTile")
        {
            render.material = afterPassing;
            boxCollider.enabled = false;
            RestartButton.boxManagers.Add(GetComponent<BoxManager>());
        }
    }

    public void ReSetBox()
    {
        render.material = beforePassing;
        boxCollider.enabled = true;
    }
}
