using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteBehaviour : MonoBehaviour
{
    public string noteText;
    public TextMeshProUGUI noteTextObject;
    public GameObject paper;
    public GameObject interactable;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //methods to show wheter or not Item is interactable
    public void showImage()
    {
        interactable.SetActive(true);
    }
    public void hideImage()
    {
        interactable.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        showImage();
    }

    private void OnTriggerExit(Collider other)
    {
        hideImage();
    }
}
