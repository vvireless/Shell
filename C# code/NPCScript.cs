using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour, Interactable
{
    [SerializeField] DialogueText dialogue;
    public void Interact()
    {
        DialogueScript.Instance.ShowDialog(dialogue);
    }
     
}
