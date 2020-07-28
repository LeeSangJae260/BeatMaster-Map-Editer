using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using LS.GeneratorNord;
using LS.Arrival_Point;

//비트제작 노드에 들어갈 클래스
public class Nord : MonoBehaviour
{
    public int index; //본인의 위치.
    public bool[,] nord; // 본인이 가지고있는 생성될 블럭들의 정보
    public float musicTime; // 본인이 위치한 음악 시간대
    LoadToNord g_Nord;
    PlayButton m_source;

    private void Start()
    {
        g_Nord = FindObjectOfType(typeof(LoadToNord)) as LoadToNord;
        m_source = FindObjectOfType(typeof(PlayButton)) as PlayButton;
        transform.GetChild(0).GetComponent<Text>().text = index.ToString();

        if (index == 0)
            Click();
    }
    //본인의 블럭 정보를 불러옴.
    public void Click()
    {
        GetComponent<Image>().color = Color.cyan;
        GetComponent<Button>().Select();
        
        g_Nord.SaveToggle(index);
        g_Nord.LoadToToggle(index);
        if (!m_source.GetAudioSource().isPlaying) //음악의 위치를 설정함.
        {
            m_source.GetAudioSource().time = musicTime;
            m_source.SetPlayNord(musicTime);
            m_source.SetPlayIndex(index);
        }
    }
}
