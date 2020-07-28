using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NordSave : MonoBehaviour
{
    public GameObject whatSave;
    public AudioSource audio;

    public void Save()
    {
        for (int i = 0; i < RestartButton.boxManagers.Count; i++)
        {
            RestartButton.boxManagers[i].ReSetBox();
        }

        whatSave.transform.localPosition = new Vector3(0, 0, 0.9f);
        PrefabUtility.CreatePrefab(Application.dataPath + "/Resource/NordFile/" + audio.clip.name + ".prefab", whatSave);
    }
}
