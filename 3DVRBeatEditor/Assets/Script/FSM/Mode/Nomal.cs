using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomal : FSM<MouseFSM>
{
    MouseFSM m_Owner;

    public Nomal(MouseFSM _Owner)
    {
        m_Owner = _Owner;
    }

    public override void Begin()
    {
        m_Owner.CurMode = M_mode.NOMAL;
    }

    public override void Exit()
    {
     
    }

    public override void Run()
    {
       
    }
}
