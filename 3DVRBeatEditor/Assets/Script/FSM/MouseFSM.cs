using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFSM : MonoBehaviour
{
    public M_mode CurMode;

    FSM<MouseFSM> m_mode;
    FSM<MouseFSM>[] m_array = new FSM<MouseFSM>[(int)M_mode.LENGTH];

    Transform target;
    RaycastHit hit;
    Transform posZ;

    public void Init()
    {
        m_array[(int)M_mode.CREATE] = new Create(this);
        m_array[(int)M_mode.DELETE] = new Delete(this);
        m_array[(int)M_mode.NOMAL] = new Nomal(this);

        m_mode = m_array[(int)M_mode.NOMAL];
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        m_mode.Run();
    }

    public void ChangeMode(M_mode mode)
    {
        m_mode = m_array[(int)mode];
        m_mode.Begin();
    }

    public bool GetRay(string lay = "Tile")
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        LayerMask layer = 1 << LayerMask.NameToLayer(lay);

        return Physics.Raycast(ray.origin, ray.direction * 10, out hit, layer);
    }

    public Transform GetTarget()
    {
        target = hit.collider.transform;
        return target;
    }

    public Transform GetPosZ()
    {
        return posZ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Nord"))
            posZ = other.transform;
    }
}
