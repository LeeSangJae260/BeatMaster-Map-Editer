using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS;

//블럭에 들어갈 클래스.
public class MoveBlock : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.back * (SaveToList.BPM/10) * Time.deltaTime;
    }
}
