using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Arrival_Point;
using LS;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    Vector2 size;

    int index = 0;
    float playTime = 0;

    //게임시작 함수
    public void StartGame()
    {
        music.time = 0;
        size = ArrivalPoint.GetPublicSize();
        Invoke("MusicStart",BPMComputation.GetMusicPoint(SaveToList.BPM));
        StartCoroutine("StartGameCoroutine");
    }

    //블럭생성 함수.
    IEnumerator StartGameCoroutine()
    {
        bool[,] nord = SaveToList.nordList[index]; //저장된 차례대로 노드들의 정보를 받아옴

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                if (NordToPosition(x,y).x == 0 && x / 2 != 0)
                {
                    break;
                }
                ArrayNordTile.nordTile[x, y].CreateBlocks(nord[x,y]);
            }
        }

        index++;
        playTime += BPMComputation.GetBPM(SaveToList.BPM); // 음악 재생 시간.
        yield return new WaitForSeconds(BPMComputation.GetBPM(SaveToList.BPM)); //블럭 소환 간격
        if(music.clip.length >= playTime)
        {
            StartCoroutine("StartGameCoroutine");
        }
    }


    public void MusicStart()
    {
        music.Play();
    }

    public Vector2 NordToPosition(int x, int y)
    {
        return new Vector2(-size.x / 2 + 0.5f + x, -size.y / 2 + 0.5f + y);
    }
}
