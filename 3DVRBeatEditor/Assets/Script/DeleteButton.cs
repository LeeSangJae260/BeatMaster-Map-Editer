using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    public void DeleteBtn()
    {
        (FindObjectOfType(typeof(MouseFSM)) as MouseFSM).ChangeMode(M_mode.DELETE);
    }
}
