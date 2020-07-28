using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Create : FSM<MouseFSM>
{
    MouseFSM m_Owner;

    public Create(MouseFSM _Owner)
    {
        m_Owner = _Owner;
    }

    Transform target;
    Transform posZ;

    int boxIndex = 0;
    Transform showBox;
    Transform createBox;

    public override void Begin()
    {
        m_Owner.CurMode = M_mode.CREATE;
        Setting();
    }

    public override void Run()
    {
        CreateBlock();
        if (Input.GetButtonDown("Fire2"))
        {
            MonoBehaviour.Destroy(target.GetChild(0).gameObject);
            boxIndex++;
            ChangeBox();
        }
    }

    public override void Exit()
    {
        
    }

    void CreateBlock()
    {
        if (m_Owner.GetRay("Tile"))   //마우스 근처에 오브젝트가 있는지 확인
        {
            target = m_Owner.GetTarget();
            posZ = m_Owner.GetPosZ();

            if (target.tag == "Tile" || target.tag == "PlayTile")
            {
                if (target.childCount == 0)
                {
                    target.GetComponent<Toggle>().isOn = true;
                    Transform block = MonoBehaviour.Instantiate(showBox, Vector3.zero, showBox.localRotation) as Transform;
                    block.localScale = Vector3.one * 0.8333333f;
                    block.SetParent(target.transform, false);
                }
            }

            if ((target.tag == "Tile" || target.tag == "PlayTile") && posZ != null && Input.GetButtonDown("Fire1"))  // 마우스가 클릭 되면
            {
                Vector3 position = new Vector3(target.localPosition.x, target.localPosition.y, 0);
                if (SameToLocation(position))
                {
                    Transform block = MonoBehaviour.Instantiate(createBox, position, createBox.localRotation) as Transform;
                    block.SetParent(posZ, false);
                }
            }
        }
    }

    public void ChangeBox()
    {
        if (boxIndex >= CreateBoxs.ShowBox.Length)
            boxIndex = 0;
        Debug.Log(boxIndex);
        showBox = CreateBoxs.ShowBox[boxIndex];
        createBox = CreateBoxs.insetBox[boxIndex];
    }

    bool SameToLocation(Vector3 position)
    {
        for (int i = 0; i < posZ.childCount; i++)
        {
            if (posZ.GetChild(i).localPosition == position)
                return false;
        }
        return true;
    }

    public void Setting()
    {
        showBox = CreateBoxs.ShowBox[0];
        createBox = CreateBoxs.insetBox[0];
    }
}
