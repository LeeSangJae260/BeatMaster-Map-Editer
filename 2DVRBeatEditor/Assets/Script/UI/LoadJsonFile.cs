using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

//json파일을 불러옴
public class LoadJsonFile : MonoBehaviour
{
    public Transform contents;
    public Transform prefab;

    void OnEnable()
    {
        FromLoadFile();
    }

    public void FromLoadFile()
    {
        DirectoryInfo path = new DirectoryInfo(Application.dataPath + "/Resource/MusicNord/");
        FileInfo[] files = path.GetFiles("*.json");

        foreach (FileInfo f in files)
        {
            Transform obj = Instantiate(prefab, Vector3.zero,Quaternion.identity) as Transform;

            string[] str = f.Name.Split('.');

            obj.GetChild(0).GetComponent<Text>().text = str[0];
            obj.name = str[0];
            obj.SetParent(contents, false);
        }
    }
}
