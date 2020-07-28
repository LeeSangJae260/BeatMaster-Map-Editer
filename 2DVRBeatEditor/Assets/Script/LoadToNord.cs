using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LS.Arrival_Point;
using LS;

namespace LS.GeneratorNord
{
    //해당 노드들의 정보를 불러올 클래스
    public class LoadToNord : MonoBehaviour
    {
        Vector2 size;
        bool[,] nords;        

        //노드들의 정보를 불러와서 저장함.
        public void LoadToToggle(int index)
        {
            size = ArrivalPoint.GetPublicSize();

            if (SaveToList.nordList != null && index != -1)
            {
                nords = SaveToList.nordList[index];
            }
            else
            {
                nords = new bool[(int)size.x, (int)size.y];
            }

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector2 nordPosition = ArrivalPoint.NordToPosition(x, y);

                    if (nordPosition.x == 0)
                        break;

                    Toggle t_nord = ArrayNordTile.canvasToggle[x, y].GetComponent<Toggle>();
                    t_nord.isOn = nords[x, y];
                }
            }
        }

        //노드 리스트의 내용을 불러옴.
        public void SaveToggle(int index)
        {
            ArrayNordTile.toggleTile = SaveToList.nordList[index];
        }
    }
}