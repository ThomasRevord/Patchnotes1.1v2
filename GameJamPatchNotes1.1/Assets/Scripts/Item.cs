using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //variables
    public string itemName;
    public GameObject icon;
    public GameObject interactable;

    private void Start()
    {
        interactable.SetActive(false);
    }
    public string GetItem()
    {
        icon.SetActive(true);
        return itemName;      
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

    public void DestroyItem()
    {
        Destroy(gameObject);
    }


}
