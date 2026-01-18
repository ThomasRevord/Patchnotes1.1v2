using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GateBehaviour : MonoBehaviour
{
    public string key;
    public GameObject interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckKey(List<string> items)
    {
        Debug.Log(items);
        if (items.Contains(key))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
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
    public void DestroyGate()
    {
        Destroy(gameObject);
    }
}
