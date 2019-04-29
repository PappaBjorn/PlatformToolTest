using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WayPointSystem))]
//[CustomEditor(typeof(MovingPlatform))]
public class WayPointEditor : Editor
{
    private Tool lastTool;
    private GUIStyle style = new GUIStyle();

    private void OnEnable()
    {
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.black;

        lastTool = Tools.current;
        Tools.current = Tool.None;
    }

    private void OnDisable()
    {
        Tools.current = lastTool;
    }

    private void OnSceneGUI()
    {
        WayPointSystem wayPoint = (WayPointSystem)target;
        for(int i = 0; i < wayPoint.points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();
            Handles.Label(wayPoint.points[i], i.ToString(), style);
            Vector3 newPosition = Handles.PositionHandle(wayPoint.points[i], Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(wayPoint, "Moved waypoint");
                wayPoint.points[i] = newPosition;
            }
        }
    }
}