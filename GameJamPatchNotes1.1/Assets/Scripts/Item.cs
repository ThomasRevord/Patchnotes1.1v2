using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour
{
    //variables
    public string itemName;
    public GameObject icon;
    public GameObject interactable;
    //give passwords
    public bool passItem;
    public float delayTime;
    public GameObject getText;

    private void Start()
    {
        interactable.SetActive(false);
    }
    public string GetItem()
    {
        if (!passItem)
        {
            icon.SetActive(true);
        }
        else 
        {
            PlayerPrefs.SetInt(itemName, 1);
            getText.SetActive(true);
        }
        return itemName;      
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
        if (other.tag == "Player")
        {
            showImage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        { 
            hideImage();
        }
    }

    public void DestroyItem()
    {
        if(!passItem)Destroy(gameObject);
    }

    IEnumerator ShowGetText()
    {
        getText.SetActive(true);
        yield return new WaitForSeconds(delayTime);
        getText.SetActive(false);
    }
}
