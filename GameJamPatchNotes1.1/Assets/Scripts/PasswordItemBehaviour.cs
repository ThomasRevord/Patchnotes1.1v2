using UnityEngine;

public class PasswordItemBehaviour : MonoBehaviour
{
    public string prefToChange;
    public GameObject interactable;
    public GameObject touchingPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        interactable.SetActive(false);
    }
    public string GetItem()
    {
        PlayerPrefs.SetInt(prefToChange, 1);
        return prefToChange;
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
        touchingPlayer = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        hideImage();
        touchingPlayer = null;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
       
    }
}
