using LS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//토글에 들어갈 클래스.
public class Toggles : GetKeyCode
{
    public int x,y;
    public InputField inputBeatName;
    public InputField inputBPM;

    Toggle toggle;

    void Start()
    {
        toggle = transform.GetComponent<Toggle>();
    }

    void Update()
    {
        if (Input.GetKeyDown(getKeyCode) && !inputBeatName.isFocused && !inputBPM.isFocused)
        {
            toggle.isOn = !toggle.isOn;
        }

        ArrayNordTile.toggleTile[x, y] = toggle.isOn;
    }
}
