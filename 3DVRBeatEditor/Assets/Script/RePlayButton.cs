using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePlayButton : MonoBehaviour
{
    public void RePlayBtn()
    {
        Transform contents = GameObject.Find("Contents").transform;
        Transform moveBeat = GameObject.Find("MoveBeat").transform;
        AudioSource audio = FindObjectOfType(typeof(AudioSource)) as AudioSource;

        contents.localPosition = new Vector3(0, 0, 0.9f);
        moveBeat.localPosition = new Vector3(0, 0, 0.9f);
        audio.time = 0;
        
        for (int i = 0; i < RestartButton.boxManagers.Count; i++)
        {
            RestartButton.boxManagers[i].ReSetBox();
        }

        RestartButton.boxManagers.Clear();
    }
}
