using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BPM 클래스
public class BPMComputation : MonoBehaviour
{
    public static float bpmSource;

    //받은 인자값을 계산해서 반환/
    public static float GetBPM(float bpm = 120)
    {
        float fTmp = bpm / 60f;
        return bpmSource = 1f / fTmp / 4f;
    }

    //받은 인자값을 계산해서 반환. 음악의 재생되기 까지 걸리는 시간.
    public static float GetMusicPoint(float bpm = 120)
    {
        return 60 / (bpm / 10);
    }
}
