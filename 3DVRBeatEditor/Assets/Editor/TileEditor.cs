using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateTile))]
public class TileEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CreateTile tile = target as CreateTile;

        tile.GenerateTile();
    }
}
