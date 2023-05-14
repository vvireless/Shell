using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int letterSpeed;

    private bool isShowingDialog = false;

    public static DialogueScript Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(DialogueText dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
        isShowingDialog = true;
    }

    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterSpeed);
        }
    }

    private void Update()
    {
        if (isShowingDialog && Input.GetKeyDown(KeyCode.X))
        {
            dialogBox.SetActive(false);
            isShowingDialog = false;
        }
    }
}
