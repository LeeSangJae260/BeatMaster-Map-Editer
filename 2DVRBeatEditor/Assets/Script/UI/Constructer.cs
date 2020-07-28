using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS;
using LS.Arrival_Point;
public class Constructer : MonoBehaviour
{
    //초기화 클래스. 
    void Awake()
    {
        Vector2 size = ArrivalPoint.GetPublicSize();
        ArrayNordTile arrNord = new ArrayNordTile((int)size.x, (int)size.y);
        SaveToList.nordList = new List<bool[,]>();
    }
}
