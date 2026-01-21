using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GateBehaviour : MonoBehaviour
{
    public string key;
    public GameObject interactable;
    public GameObject icon;
    //dealing with passwords
    public bool codeReward;
    public string prefToChange;
    public GameObject touchingPlayer;
    public AudioSource aSource;
    public AudioClip openSound;
    
    //TODO: add failsafe so player can't increment code with same object
    //can probably use player prefs for that with each gate

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable.SetActive(false);
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
            if (codeReward)
            {
                GetPass();
            }
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
        touchingPlayer = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        hideImage();
        touchingPlayer = null;
    }
    public void DestroyGate()
    {
        icon.SetActive(false);
        interactable.SetActive(false);
        aSource.PlayOneShot(openSound);
        if (!codeReward)
        {
            touchingPlayer.GetComponent<AudioSource>().PlayOneShot(openSound);
            Destroy(gameObject);
            Debug.Log("Sound should play");
            
        }
    }

    public void GetPass()
    {
        Debug.Log("GetPass called");
        //increment code by 1
        PlayerPrefs.SetInt(prefToChange, PlayerPrefs.GetInt(prefToChange) + 1);
        if (PlayerPrefs.GetInt(prefToChange) >= 4)
        {
            touchingPlayer.GetComponent<PlayerBehaviour>().items.Add(prefToChange);
        }
    }
}
