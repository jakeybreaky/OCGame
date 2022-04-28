using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInteractable : Interactable
{
    //Opens the dialogue box when the object is interacted with

    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private DialogueSystem dialogueSystem;

    void Start()
    {
        dialogueSystem = dialogueUI.GetComponent<DialogueSystem>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && playerInRange && !dialogueSystem.IsOpen)
        {
            foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
            {
                if (responseEvents.DialogueObject == dialogueObject)
                {
                    dialogueSystem.AddResponseEvents(responseEvents.Events);
                    break;
                }
            }

            dialogueSystem.ShowDialogue(dialogueObject);
        }
    }
}
