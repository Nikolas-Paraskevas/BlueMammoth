using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class interactable : MonoBehaviour
{
    Outline outline;
    public string message;

    public UnityEvent onInteraction;

    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void Interact()
    {
        //onInteraction.Invoke();
        Debug.Log("item taken");
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
