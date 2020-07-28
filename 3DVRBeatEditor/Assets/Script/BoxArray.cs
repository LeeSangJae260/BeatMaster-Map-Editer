using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxArray : MonoBehaviour
{
    public Transform[] showBox;
    public Transform[] createBox;

    public void SetBoxs()
    {
        CreateBoxs.ShowBox = showBox;
        CreateBoxs.insetBox = createBox;
        (FindObjectOfType(typeof(MouseFSM)) as MouseFSM).ChangeMode(M_mode.CREATE);
    }
}
