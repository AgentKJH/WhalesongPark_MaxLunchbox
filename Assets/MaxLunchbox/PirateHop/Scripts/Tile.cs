using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

enum TileTypes
{
    Safe,
    Unsafe
}

public class Tile : MonoBehaviour
{
    [HideInInspector]
    public int arrayIndex = 0;

    [HideInInspector]
    public string[] tileTypes = new string[] {"Safe", "Unsafe"};
}

[CustomEditor(typeof(Tile))]
public class DropdownEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Tile script = (Tile)target;

        GUIContent tileType = new GUIContent("Tile Type");
        script.arrayIndex = EditorGUILayout.Popup(tileType, script.arrayIndex, script.tileTypes);
    }
}
