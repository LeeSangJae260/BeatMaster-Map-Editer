using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LS
{
    //전체적으로 쓰일 변수를 담은 클래스
    public class ArrayNordTile
    {
        public static CreateNord.CreateBlock[,] nordTile; //블럭 생성자의 위치값을 담을 변수
        public static Transform[,] canvasToggle; //노드 토글의 위치값을 담을 변수
        public static bool[,] toggleTile; //노드의 생성정보를 담을 변수
        public static List<Nord> nordIntervals; // 노드들을 담을 리스트변수

        public ArrayNordTile(int x, int y)//생성자.
        {
            nordTile = new CreateNord.CreateBlock[x, y];
            canvasToggle = new Transform[x, y];
            toggleTile = new bool[x, y];
            nordIntervals = new List<Nord>();
        }
    }
}