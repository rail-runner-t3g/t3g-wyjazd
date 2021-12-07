using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxAggregatorWindow : EditorWindow
{
    private readonly List<Box> boxes = new();

    [MenuItem("Szpadel Gamedev/Box Aggregator")]
    public static void OpenWindow()
    {
        BoxAggregatorWindow window = GetWindow<BoxAggregatorWindow>("Box Aggregator");
        window.minSize = new Vector2(300, 200);
        window.Show();
    }

    public void OnGUI()
    {

        GUILayout.Label("Znajduje wszystkie assety typu Box w projekcie.");
        if (GUILayout.Button("Find boxes"))
        {
            boxes.Clear();
            string[] assets = AssetDatabase.FindAssets("t:Box");

            foreach (string asset in assets)
            {
                string boxAssetPath = AssetDatabase.GUIDToAssetPath(asset);
                Box boxAsset = AssetDatabase.LoadAssetAtPath<Box>(boxAssetPath);

                boxes.Add(boxAsset);
            }
        }

        EditorGUI.BeginDisabledGroup(true);
        for (int i = 0; i < boxes.Count; i++)
        {
            Box box = boxes[i];
            EditorGUILayout.ObjectField("Element " + i, box, typeof(Box));
        }
        EditorGUI.EndDisabledGroup();
    }
}
