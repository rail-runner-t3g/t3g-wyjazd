using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RandomIntValue))]
public class RandomIntValuePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var minProperty = property.FindPropertyRelative("Min");
        var maxProperty = property.FindPropertyRelative("Max");

        var valueRect = EditorGUI.PrefixLabel(position, label);

        var minRect = new Rect(valueRect.x, valueRect.y, valueRect.width / 2, valueRect.height);
        var maxRect = new Rect(valueRect.x + minRect.width, valueRect.y, valueRect.width / 2, valueRect.height);

        minProperty.intValue = EditorGUI.IntField(minRect, minProperty.intValue);
        maxProperty.intValue = EditorGUI.IntField(maxRect, minProperty.intValue);
    }
}
