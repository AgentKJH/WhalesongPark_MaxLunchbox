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
    private int arrayIndex = 0;

    [HideInInspector]
    public string[] tileTypes = new string[] { "Safe", "Unsafe" };

    public int ArrayIndex
    {
        get
        {
            if (arrayIndex == (int)TileTypes.Safe)
            {
                print("Safe tile");
            }
            else if (arrayIndex == (int)TileTypes.Unsafe)
            {
                print("Unsafe tile");
            }

            return arrayIndex;
        }
        set
        {
            ArrayIndex = value;
        }
    }
}

[CustomEditor(typeof(Tile))]
public class DropdownEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Tile script = (Tile)target;

        GUIContent tileType = new GUIContent("Tile Type");
        script.ArrayIndex = EditorGUILayout.Popup(tileType, script.ArrayIndex, script.tileTypes);
    }
}
