using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToJ;

//Makes wall transparent when you walk behind it
public class XRay : MonoBehaviour
{
    public Mask mask;

    void Start()
    {
        mask = GetComponent<Mask>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mask.IsMaskingEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mask.IsMaskingEnabled = false;
        }
    }
}
