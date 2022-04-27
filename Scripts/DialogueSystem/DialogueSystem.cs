using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textToOverwrite;

    [SerializeField] private Signal interactionOpen;
    [SerializeField] private Signal interactionClose;
    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        interactionOpen.Raise();

        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    public void HandleDialogueEvents(DialogueEvent[] dialogueEvents)
    {
        //This method will be called when a new line of dialogue is displayed from the StepThroughDialogue Method, and invoke the events ascociated with the dialogue.
        //This will let us change images and such.
        //We still need to make a script for visual novel images, overworld portraits, etc.
        //Remember: It's important that everything works by itself. Modular is the key.


    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            //Pass dialogue events from dialogue i through to the handleDialogueEvents method and have it invoke events if needed. You can copy/paste most of the code from the Response Handler.

            yield return RunTypingEffect(dialogue);

            textToOverwrite.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        dialogueObject.seenDialogue = true;

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }

        else
        {
            CloseDialogueBox();
        }
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textToOverwrite);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                typewriterEffect.Stop();
            }
        }
    }

    public void CloseDialogueBox()
    {
        IsOpen = false;
        interactionClose.Raise();
        dialogueBox.SetActive(false);
        textToOverwrite.text = string.Empty;
    }
}
