using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseWheel : MonoBehaviour
{
    public Transform contents;
    public Transform beats;
    public Transform isBeats;

    public InputField bpm;
    void Update()
    {
        Debug.Log(PlayButton.publicAudio.time);
        if (isBeats.childCount != 0)
        {
            float wheel = Input.GetAxis("Mouse ScrollWheel");
            if (!PlayButton.playBollen && wheel < 0)
            {
                Debug.Log(PlayButton.publicAudio.time);
                contents.localPosition += Vector3.back * BPMComputation.GetBPM(float.Parse(bpm.text)) * (2.544f / BPMComputation.GetBPM(float.Parse(bpm.text)));
                beats.localPosition += Vector3.back * BPMComputation.GetBPM(float.Parse(bpm.text)) * (2.544f / BPMComputation.GetBPM(float.Parse(bpm.text)));

                if (PlayButton.publicAudio.time < PlayButton.publicAudio.clip.length)
                {
                    PlayButton.publicAudio.time += BPMComputation.GetBPM(float.Parse(bpm.text)) * 1.72f;
                }
                else if (PlayButton.publicAudio.time > PlayButton.publicAudio.clip.length)
                {
                    PlayButton.publicAudio.time = PlayButton.publicAudio.clip.length;
                }
            }
            else if (!PlayButton.playBollen && wheel > 0)
            {
                Debug.Log(PlayButton.publicAudio.time);
                contents.localPosition += Vector3.forward * BPMComputation.GetBPM(float.Parse(bpm.text)) * (2.544f / BPMComputation.GetBPM(float.Parse(bpm.text)));
                beats.localPosition += Vector3.forward * BPMComputation.GetBPM(float.Parse(bpm.text)) * (2.544f / BPMComputation.GetBPM(float.Parse(bpm.text)));

                if (PlayButton.publicAudio.time > .1f)
                {
                    PlayButton.publicAudio.time -= BPMComputation.GetBPM(float.Parse(bpm.text)) * 1.72f;
                }
                else if (PlayButton.publicAudio.time < 0)
                {
                    PlayButton.publicAudio.time = 0;
                }
            }
        }
    }
}
