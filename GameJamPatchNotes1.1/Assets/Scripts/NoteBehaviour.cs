using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteBehaviour : MonoBehaviour
{
    public string noteText;
    public TextMeshProUGUI noteTextObject;
    public GameObject paper;
    public GameObject interactable;
    public bool touchingPlayer;
    public AudioSource aSource;
    public AudioClip noteSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        touchingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer == true)
        {
            showNote();
        }
    }

    //methods to show wheter or not Item is interactable
    public void showImage()
    {
        Debug.Log("Show image called");
        interactable.SetActive(true);
    }
    public void hideImage()
    {
        Debug.Log("Hide image called");
        interactable.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        showImage();
        touchingPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hideImage();
        touchingPlayer = false;
        hideNote();
    }

    public void showNote()
    {
        paper.SetActive(true);
        interactable.SetActive(false);
        noteTextObject.text = noteText;
        SoundManager.PlaySound("Paper");
    }

    public void hideNote()
    {
        paper.SetActive(false);
        noteTextObject.text = "";
    }
}
