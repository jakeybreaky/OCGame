using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueEvent
{
    [HideInInspector] public string name;
    [SerializeField] private UnityEvent onShowLine;

    public UnityEvent OnShowLine => onShowLine;
}
