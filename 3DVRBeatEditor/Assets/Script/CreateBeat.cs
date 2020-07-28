using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CreateBeat : MonoBehaviour
{
    //인스팩터
    public Transform beat; //생성될 비트
    public Transform nord; //생성될 노드
    public AudioSource audioSource; //오디오소스
    public InputField bpm; //bpm입력창
    public Text text;

    //스테이터스
    int index;

    void Start()
    {
       // CreateBeats();
    }

    //비트 생성 
    public void CreateBeats(Transform parent)
    {
        text.text = bpm.text;
        //간격  + 2.544f
        float interval = 0;

        for (float i = 0; i < audioSource.clip.length; i += BPMComputation.GetBPM(float.Parse(bpm.text)) * 1.69f)
        {
            Transform bt = Instantiate(beat, parent.transform.position,Quaternion.identity) as Transform;
            bt.position = new Vector3(0, 0, interval);
            bt.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = (++index).ToString();

            bt.SetParent(parent.transform, false);

            interval += 2.544f;
        }
    }

    public void CreateNords(Transform parent)
    {
        //간격  + 2.544f
        float interval = 0;

        for (float i = 0; i < audioSource.clip.length; i += BPMComputation.GetBPM(float.Parse(bpm.text)) * 1.69f)
        {
            Transform bt = Instantiate(nord, parent.transform.position, Quaternion.identity) as Transform;
            bt.position = new Vector3(0, 0, interval);

            bt.SetParent(parent.transform, false);

            interval += 2.544f;
        }
    }

}
