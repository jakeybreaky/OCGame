using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueEvents))]
public class DialogueEventsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueEvents dialogueEvents = (DialogueEvents)target;

        if (GUILayout.Button("Refresh"))
        {
            dialogueEvents.OnValidate();
        }
    }
}