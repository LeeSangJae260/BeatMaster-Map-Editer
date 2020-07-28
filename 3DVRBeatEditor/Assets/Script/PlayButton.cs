using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public AudioSource audio;
    public Transform isBeats;

    bool play = false;

    public static AudioSource publicAudio;
    public static bool playBollen;

    void Start()
    {
        playBollen = play;
        publicAudio = audio;
    }
    public void MusicPlay()
    {
        if (isBeats.childCount != 0)
        {
            play = !play;
            playBollen = play;
            MoveBeat.isMove = play;

            if (play)
            {
                audio.Play();
                PlayBeat();
            }
            else
            {
                audio.Pause();
                PauseBeat();
            }
        }
    }

    void PlayBeat()
    {
        for (int i = 0; i < CreateTile.tilesColl.Count; i++)
        {
            CreateTile.tilesColl[i].tag = "PlayTile";
        }
    }

    void PauseBeat()
    {
        for (int i = 0; i < CreateTile.tilesColl.Count; i++)
        {
            CreateTile.tilesColl[i].tag = "Tile";
        }
    }
}
