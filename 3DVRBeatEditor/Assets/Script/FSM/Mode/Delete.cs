using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : FSM<MouseFSM>
{
    MouseFSM m_Owner;

    public Delete(MouseFSM _Owner)
    {
        m_Owner = _Owner;
    }


    public override void Begin()
    {
        m_Owner.CurMode = M_mode.DELETE;
        for (int i = 0; i < CreateTile.tilesColl.Count; i++)
        {
            if(CreateTile.tilesColl[i].transform.childCount != 0)
                MonoBehaviour.Destroy(CreateTile.tilesColl[i].transform.GetChild(0).gameObject);
        }

        for (int i = 0; i < RestartButton.boxManagers.Count; i++)
        {
            RestartButton.boxManagers[i].ReSetBox();
        }
        RestartButton.boxManagers.Clear();
    }

    public override void Exit()
    {
        
    }

    public override void Run()
    {
        DeleteBox();
    }

    void DeleteBox()
    {
        if (m_Owner.GetRay("Box"))
        {
            if(m_Owner.GetTarget().gameObject.layer == LayerMask.NameToLayer("Box") && Input.GetButtonDown("Fire1"))
            {
                MonoBehaviour.Destroy(m_Owner.GetTarget().gameObject);
            }
        }
    }
}
