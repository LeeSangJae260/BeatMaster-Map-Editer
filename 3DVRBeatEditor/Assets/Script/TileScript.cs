using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if(transform.childCount != 0)
            if (toggle.isOn == false)
                Destroy(transform.GetChild(0).gameObject);

    }
}
