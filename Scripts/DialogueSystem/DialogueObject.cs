using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;
    public string[] Dialogue => dialogue;
    public Response[] Responses => responses;
    public bool HasResponses => Responses != null && Responses.Length > 0;

    public bool seenDialogue;



}