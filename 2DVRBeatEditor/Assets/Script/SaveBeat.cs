using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using LS.Arrival_Point;
using LS;


//.json 파일을 만드는 세이브 클레스
public class SaveBeat : MonoBehaviour
{
    [SerializeField] InputField beatName; //파일 이름.
    [SerializeField] InputField BPM; //음악의 BPM 
    [SerializeField] AudioSource audiosource; //음악의 이름

    public GameManager g_main; // 게임 매니저
    public Canvas canvas; //캔버스

    SaveToJson saveToJson; //저장될 클래스

    public void SaveToBeat() //저장 함수
    {
        if (beatName.text != "" && BPM.text != "") //입력칸이 비어있으면 저장이 안됌
        {
            SaveToList.beatName = beatName.text;
            SaveToList.musicName = audiosource.clip.name;
            SaveToList.BPM = float.Parse(BPM.text);

            saveToJson = new SaveToJson(SaveToList.beatName, SaveToList.musicName,SaveToList.BPM, SaveToList.nordList);//클래스 초기화
            SaveNordToJson();
            Debug.Log(saveToJson.musicName + " : 세이브 성공");
        }
    }

    void SaveNordToJson()//json 파일 생성
    { 
        string jsonDate = JsonUtility.ToJson(saveToJson,true); //1번째 인자의 내용을 저장, 2번째 인자는 읽기 쉽게 저장할지 말지를 정함.
        string path = Application.dataPath +  "/Resource/MusicNord/" + saveToJson.beatName + ".json";//저장될 주소.
        File.WriteAllText(path, jsonDate);// 파일생성
    }


}

    [System.Serializable]
    public class SaveToJson
    {
        public string beatName;
        public string musicName;
        public float BPM;
        public List<ArrayNordList> listArr;


        public SaveToJson(string b_name, string m_name,float bpm, List<bool[,]> list )//생성자.
        {
            beatName = b_name;
            musicName = m_name;
            BPM = bpm;
            listArr = new List<ArrayNordList>();
            Debug.Log(list.Count);
            // 2차배열의 리스트를 직렬화.
            Vector2 size = ArrivalPoint.GetPublicSize();
            ArrayNordList arrTemp = new ArrayNordList();
            arrTemp.x = new JsonArrayX[(int)size.x];
            for (int i = 0; i < list.Count; i++)
            {
                bool[,] temp = list[i];
                JsonArrayX[] YnordList = new JsonArrayX[(int)size.x];
                for (int x = 0; x < size.x; x++)
                {
    
                    YnordList[x] = new JsonArrayX((int)size.y);
                    for (int y = 0; y < size.y; y++)
                    {
                        if (ArrivalPoint.NordToPosition(x, y).x == 0)
                            break;

                        YnordList[x].JsonArrayY[y] = temp[x, y];
                    }
    
                }
                arrTemp.x = YnordList;

                listArr.Insert(i, arrTemp);
            }
        }
    }

    [System.Serializable]
    public struct ArrayNordList
    {
        public JsonArrayX[] x;
    }

    [System.Serializable]
    public struct JsonArrayX
    {
        public bool[] JsonArrayY;

        public JsonArrayX(int y)
        {
            this.JsonArrayY = new bool[y];
        }
    }