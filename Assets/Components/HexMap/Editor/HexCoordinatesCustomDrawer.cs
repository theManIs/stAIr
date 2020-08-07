using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CustomPropertyDrawer(typeof(HexCoordinates))]
    public class HexCoordinatesCustomDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            HexCoordinates coordinates = new HexCoordinates(
                property.FindPropertyRelative("x").intValue,
                property.FindPropertyRelative("z").intValue
            );

            Rect valuePosition = EditorGUI.PrefixLabel(position, label);

            GUI.Label(valuePosition, coordinates.ToString());
        }
    }
}