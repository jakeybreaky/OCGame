using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvents : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private DialogueEvent[] events;

    public DialogueObject DialogueObject => dialogueObject;

    public DialogueEvent[] Events => events;
    public void OnValidate()
    {
        if (dialogueObject == null) return;
        if (dialogueObject.Dialogue == null) return;
        if (events != null && events.Length == dialogueObject.Dialogue.Length) return;

        if (events == null)
        {
            events = new DialogueEvent[dialogueObject.Dialogue.Length];
        }

        else
        {
            Array.Resize(ref events, dialogueObject.Dialogue.Length);
        }

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            //Response response = dialogueObject.Responses[i];

            if (events[i] != null)
            {
                events[i].name = dialogueObject.Dialogue[i];
                continue;
            }

            events[i] = new DialogueEvent() { name = dialogueObject.Dialogue[i] };
        }
    }
}
