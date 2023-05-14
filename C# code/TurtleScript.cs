using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScript : MonoBehaviour, Interactable
{
    [SerializeField] DialogueText dialogue;
    [SerializeField] GameObject newCamera; // Add the camera as a public GameObject variable
    [SerializeField] GameObject DialogueBox1; // Add the camera as a public GameObject variable

    public void Interact()
    {
        DialogueScript.Instance.ShowDialog(dialogue);

        StartCoroutine(ChangeCamera());

    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(3f);
        Camera.main.gameObject.SetActive(false);
        DialogueBox1.SetActive(false);
        newCamera.SetActive(true); 
    }
}
