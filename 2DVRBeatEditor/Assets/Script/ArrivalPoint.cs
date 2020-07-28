using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS;

namespace LS.Arrival_Point
{
    //블럭생성자를 만들어내는 클래스.
    public class ArrivalPoint : MonoBehaviour
    {
        [Header("Tile State")]
        [SerializeField] Vector2 size;
        [SerializeField] Transform tile;
        [Space (10f)]
        [SerializeField] Transform generatorNordTile_B;
        [SerializeField] Transform generatorNordTile_R;
        [Range (0,5)]public float tileSize;
        [SerializeField] int nordPosition;

        [Header("Toggle State")]
        [SerializeField] RectTransform parentObj;
        [SerializeField] RectTransform toggle_B;
        [SerializeField] RectTransform toggle_R;
        [Range(0, 5)] [SerializeField] float toggleSize;


        public static Vector2 publicSize;
        public static float publicTileSize;
        public static int publicNordPosition;
        bool[,] nords;

        void Awake()
        {
            publicSize = size;
            publicTileSize = tileSize;
            publicNordPosition = nordPosition;
        }

        void Start()
        {
            GenerateTile();
            SettingToggle();
        }

        //끝 지점과 시작지점을 생성함
        public void GenerateTile()
        {
            string tileHolderName = "Tile Holder";
            string nordHolderName = "Nord Holder";
            Transform nordTIle;

            if (transform.FindChild(tileHolderName) || transform.FindChild(nordHolderName))
            {
                DestroyImmediate(transform.FindChild(tileHolderName).gameObject);
                DestroyImmediate(transform.FindChild(nordHolderName).gameObject);
            }

            Transform tileHolder = new GameObject(tileHolderName).transform;
            Transform nordHolder = new GameObject(nordHolderName).transform;
            tileHolder.parent = transform;
            nordHolder.parent = transform;

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector2 nordPosition = NordToPosition(x, y) * tileSize;

                    if (nordPosition.x == 0)
                        break;

                    Transform nord = Instantiate(tile, nordPosition, Quaternion.identity) as Transform;
                    nord.localScale =  Vector3.one * tileSize;
                    nord.parent = tileHolder;
                }
            }

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector3 nordPosition = NordToPosition(x, y, this.nordPosition);

                    if (nordPosition.x == 0)
                        break;

                    if (nordPosition.x < 0)
                        nordTIle = generatorNordTile_B;
                    else
                        nordTIle = generatorNordTile_R;

                    Transform nord = Instantiate(nordTIle, nordPosition, Quaternion.identity) as Transform;
                    nord.localScale = Vector3.one * tileSize;
                    nord.parent = nordHolder;
                    ArrayNordTile.nordTile[x, y] = nord.GetComponent<CreateNord.CreateBlock>();
                }
            }
        }

        //입력을 받을 토글을 생성함
        public void GenerateToggle(int index)
        {
            string tileHolderName = "Toggle Holder";
            Transform toggleTile;

            if (parentObj.FindChild(tileHolderName))
            {
                DestroyImmediate(parentObj.FindChild(tileHolderName).gameObject);
            }

            if (SaveToList.nordList != null && index != -1)
            {
                nords = SaveToList.nordList[index];
            }
            else
            {
                nords = new bool[(int)size.x, (int)size.y];
            }

            Transform toggleHolder = new GameObject(tileHolderName).transform;
            toggleHolder.SetParent(parentObj, false);

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Vector2 nordPosition = NordToPosition(x, y) * toggle_B.sizeDelta * toggleSize;

                    if (nordPosition.x == 0)
                        break;

                    if (nordPosition.x < 0)
                        toggleTile = toggle_B;
                    else
                        toggleTile = toggle_R;

                    Transform nord = Instantiate(toggleTile, nordPosition, Quaternion.identity) as Transform;
                    nord.localScale = Vector3.one * toggleSize;
                    nord.SetParent(toggleHolder, false);
                    Toggles t_nord = nord.GetComponent<Toggles>();
                    t_nord.x = x; t_nord.y = y;
                    ArrayNordTile.canvasToggle[x, y] = nord;
                }
            }
        }

        //토글들의 위치값을 저장할 함수
        public void SettingToggle()
        {
            int index = 0;
            Transform parent = parentObj.GetChild(0);
            Transform[] nords = new Transform[parent.childCount];
            for (int i = 0; i < parent.childCount; i++)
            {
                nords[i] = parent.GetChild(i);
            }

            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    if (NordToPosition(x, y).x == 0)
                        break;

                    Toggles t_nord = nords[index].GetComponent<Toggles>();
                    t_nord.x = x; t_nord.y = y;
                    ArrayNordTile.canvasToggle[x, y] = nords[index++];
                }

            }
        }

        public static Vector2 GetPublicSize()
        {
            return publicSize;
        }

        public static Vector2 NordToPosition(int x, int y)
        {
            return new Vector2(-publicSize.x / 2 + 0.5f + x, -publicSize.y / 2 + 0.5f + y);
        }

        public Vector3 NordToPosition(int x, int y, int z)
        {
            return new Vector3((-size.x / 2 + 0.5f + x) * tileSize,(-size.y / 2 + 0.5f + y) * tileSize, z);
        }
    }
}