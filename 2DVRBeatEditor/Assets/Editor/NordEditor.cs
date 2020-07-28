using UnityEngine;
using UnityEditor;
using LS.Arrival_Point;

[CustomEditor(typeof(ArrivalPoint))]
public class NordEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ArrivalPoint tile = target as ArrivalPoint;

        tile.GenerateTile();
    }
}
