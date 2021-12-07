using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Box))]
public class BoxEditor : Editor
{
    private SerializedProperty pointsProperty;
    private int valueA = 0;
    private int valueB = 0;

    private void OnEnable()
    {
        pointsProperty = serializedObject.FindProperty("points");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        valueA = EditorGUILayout.IntField("Value A", valueA);
        valueB = EditorGUILayout.IntField("Value B", valueB);

        EditorGUILayout.PropertyField(pointsProperty);
        if (GUILayout.Button("Press Me"))
        {
            pointsProperty.intValue = valueA + valueB;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
