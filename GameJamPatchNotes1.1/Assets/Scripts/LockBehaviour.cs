using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LockBehaviour : MonoBehaviour
{
    //spritesheet
    public Sprite[] sprites;
    public int currentNum;
    public int correctNum;
    public GameObject touchingPlayer;
    public bool keySet;
    public GameObject interactable;
    public string keyName;
    public GameObject icon;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keySet = false;
        touchingPlayer = null;
    }

    // Update is called once per frame
    void Update()
    {     
        //check if player is interacting
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer != null)
        {
            //check if player has key and key isn't set
            if (keySet == false && touchingPlayer.GetComponent<PlayerBehaviour>().items.Contains(keyName))
            {
                //set up putting key in
                touchingPlayer.GetComponent<PlayerBehaviour>().items.Remove(keyName);
                icon.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                currentNum = 1;
                keySet = true;
            }
            //if key is set
            else 
            {
                //increment current num
                if (currentNum == 6)
                {
                    currentNum = 1;
                }
                else 
                {
                    currentNum++;
                }
                //change sprite
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentNum];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        showImage();
        if (other.tag == "Player")
        {
            touchingPlayer = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        hideImage();
        touchingPlayer = null;
    }
    public void showImage()
    {
        interactable.SetActive(true);
    }
    public void hideImage()
    {
        interactable.SetActive(false);
    }
    public bool CheckLock()
    {
        if (currentNum == correctNum)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

   
}
