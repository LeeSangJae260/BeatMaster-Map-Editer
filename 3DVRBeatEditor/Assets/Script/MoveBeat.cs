using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveBeat : MonoBehaviour
{
    public InputField inputBpm;

    float bpm;
    public static bool isMove = false;

    void OnEnable()
    {
        if(inputBpm == null)
        {
            bpm = float.Parse(transform.Find("Text").GetComponent<Text>().text);
        }
    }

    void Update()
    {
        if (isMove)
            Move();

        if ((Vector3.forward * 0.9f).z < transform.localPosition.z)
        {
            transform.localPosition = (Vector3.forward * 0.9f);
        }
    }

    public void IsMove()
    {
        bpm = float.Parse(inputBpm.text);
        if (transform.childCount != 0)
            isMove = !isMove;
    }

    public void Move()
    {
        transform.localPosition += Vector3.back * (bpm / 10) * Time.deltaTime;
    }
}
