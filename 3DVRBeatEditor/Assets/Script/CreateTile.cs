using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateTile : MonoBehaviour
{
    [Header("Tile State")]
    [SerializeField] Vector2 size;
    [SerializeField] Transform tile;
    [Range(0, 5)] public float tileSize;

    public static List<GameObject> tilesColl = new List<GameObject>();

    void Start()
    {
        GenerateTile();
    }

    //타일 생성
    public void GenerateTile()
    {
        string tileHolderName = "Tile Holder";
        Transform nordTIle;

        if (transform.Find(tileHolderName))
        {
            DestroyImmediate(transform.Find(tileHolderName).gameObject);
        }

        Transform tileHolder = new GameObject(tileHolderName).transform;
        tileHolder.gameObject.AddComponent<ToggleGroup>();
        tileHolder.SetParent(transform,false);

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector2 nordPosition = NordToPosition(x, y) * tileSize;

                Transform nord = Instantiate(tile, nordPosition, Quaternion.identity) as Transform;
                nord.localScale = Vector3.one * tileSize;
                nord.GetComponent<Toggle>().group = tileHolder.GetComponent<ToggleGroup>();
                nord.SetParent(tileHolder,false);
                tilesColl.Add(nord.gameObject);
            }
        }
    }

    public Vector2 NordToPosition(int x, int y)
    {
        return new Vector2(-size.x / 2 + 0.5f + x, -size.y / 2 + 0.5f + y);
    }
}
