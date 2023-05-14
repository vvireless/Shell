using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    [SerializeField] private GameObject rightAnswerText; // reference to the text object
    [SerializeField] GameObject prevCamera; // Add the camera as a public GameObject variable
    [SerializeField] GameObject newCamera; // Add the camera as a public GameObject variable

    private void Start()
    {
        rightAnswerText.SetActive(false); // hide the text object initially
    }

    public void OnButtonClick()
    {
        rightAnswerText.SetActive(true); // make the text object appear
        StartCoroutine(ChangeCamera());

    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(3f);
        prevCamera.SetActive(false);
        newCamera.SetActive(true);
    }
}
