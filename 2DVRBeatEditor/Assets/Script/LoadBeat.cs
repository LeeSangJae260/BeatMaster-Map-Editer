using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.IO;
using LS.Arrival_Point;
using LS;

//json파일을 불러올 클래스
public class LoadBeat : MonoBehaviour
{
    public string loadToJson; //파일의 이름.

    Vector2 size; //노드 사이즈.
    GameObject canvas; //캔버스

    private void Start()
    {
        size = ArrivalPoint.GetPublicSize();
        canvas = GameObject.Find("LS_Canvas");
        loadToJson = transform.name;
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadFromJsonData();
        }
    }*/

    //json파일의 내용을 불러오는 함수. 버튼에 들어감
    public void LoadFromJsonData()
    {
        string path = Application.dataPath + "/Resource/MusicNord/" + loadToJson + ".json";
        string jsonDat = File.ReadAllText(path);
        SaveToJson loadData = JsonUtility.FromJson<SaveToJson>(jsonDat);

        SaveToList.BPM = loadData.BPM;

        List<ArrayNordList> list = loadData.listArr;

        SaveToList.nordList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            bool[,] nord = new bool[(int)size.x,(int)size.y];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    if (ArrivalPoint.NordToPosition(x, y).x == 0)
                        break;

                    nord[x, y] = list[i].x[x].JsonArrayY[y];
                }
            }
            SaveToList.nordList.Add(nord);
        }

        (FindObjectOfType(typeof(GameManager)) as GameManager).StartGame();
        canvas.SetActive(false);
    }

    public void Load()
    {
        string path = Application.dataPath + "/Resource/MusicNord/" + loadToJson + ".json";
        string jsonDat = File.ReadAllText(path);
        SaveToJson loadData = JsonUtility.FromJson<SaveToJson>(jsonDat);

        SaveToList.BPM = loadData.BPM;

        List<ArrayNordList> list = loadData.listArr;

        SaveToList.nordList.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            bool[,] nord = new bool[(int)size.x, (int)size.y];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    if (ArrivalPoint.NordToPosition(x, y).x == 0)
                        break;

                    nord[x, y] = list[i].x[x].JsonArrayY[y];
                }
            }
            SaveToList.nordList.Add(nord);
        }

        (FindObjectOfType(typeof(PlayButton)) as PlayButton).LoadBeat();
        transform.parent.parent.parent.gameObject.SetActive(false);
    }
}
