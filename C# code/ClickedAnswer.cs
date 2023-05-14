using UnityEngine;
using UnityEngine.UI;

public class ClickedAnswer : MonoBehaviour
{
    [SerializeField] GameObject prevCamera; // Add the camera as a public GameObject variable
    [SerializeField] GameObject newCamera; // Add the camera as a public GameObject variable
    public Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.GetComponent<Button>().onClick.AddListener(OnTextClicked);
    }

    public void OnTextClicked()
    {
        prevCamera.SetActive(false);
        newCamera.SetActive(true);
    }
}
