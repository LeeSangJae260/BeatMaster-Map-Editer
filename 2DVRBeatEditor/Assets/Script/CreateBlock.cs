using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS.Arrival_Point;


namespace LS.CreateNord
{
    //생성될 블럭의 클래스
    public class CreateBlock : MonoBehaviour
    {
        public Transform block;

        public void CreateBlocks(bool isCreate)
        {
            if (isCreate)
            {
                Transform nord = Instantiate(block, transform.position, Quaternion.identity);
                nord.localScale = Vector3.one * LS.Arrival_Point.ArrivalPoint.publicTileSize;
            }
        }
    }
}