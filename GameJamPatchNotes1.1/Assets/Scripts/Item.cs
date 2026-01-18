using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //variables
    public string itemName;
    public Sprite icon;
    public GameObject interactable;

    private void Start()
    {
        
    }
    public string GetItem()
    {
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
