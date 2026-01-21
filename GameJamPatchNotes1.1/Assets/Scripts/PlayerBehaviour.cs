using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBehaviour : MonoBehaviour
{
    //variables
    public float speed;
    public Rigidbody rigid;
    public Vector3 rotation;
    public float rotateSpeed;
    //inventory system
    public List<string> items;
    public Item stored = null;
    public GameObject gate;
    public AudioSource aSource;
    public AudioClip walkSound;
    public float walkDelayTime;
    public bool playingSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playingSound = false;
        //check passwords
        if (PlayerPrefs.GetInt("Code1") == 1)
        {
            items.Add("Code1");
        }
        if (PlayerPrefs.GetInt("Code2") == 1)
        {
            items.Add("Code2");
        }
        if (PlayerPrefs.GetInt("Code3") == 1)
        {
            items.Add("Code3");
        }
        if (PlayerPrefs.GetInt("Code4") == 1)
        {
            items.Add("Code4");
        }
        if (PlayerPrefs.GetInt("Pass1") == 1)
        {
            items.Add("Pass1");
        }
        if (PlayerPrefs.GetInt("Pass2") == 1)
        {
            items.Add("Pass2");
        }
        if (PlayerPrefs.GetInt("Pass3") == 1)
        {
            items.Add("Pass3");
        }
        if (PlayerPrefs.GetInt("Pass4") == 1)
        {
            items.Add("Pass4");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //movement (using old input system)
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if(!playingSound)StartCoroutine(PlayWalk());
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            if (!playingSound) StartCoroutine(PlayWalk());
        }
        //disable coroutine when keys are lifted
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            StopCoroutine(PlayWalk());
            aSource.Stop();
        }
       //rotation (using old input system)
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotation * rotateSpeed * Time.deltaTime * -1);
        }
        //when player presses E key
        if (Input.GetKeyDown(KeyCode.E) && stored != null)
        {
            //add to inventory
            //if it isn't in inventory already, add it
            if (!items.Contains(stored.GetItem()))
            { 
                items.Add(stored.GetItem()); 
            }
            stored.hideImage();
            stored.DestroyItem();
            //clear stored
            stored = null;
        }
        else if (Input.GetKeyDown(KeyCode.E) && gate != null)
        {

            //check if player has key
            bool hasItem = gate.GetComponent<GateBehaviour>().CheckKey(items);
            
            //if they do
            if (hasItem == true)
            {
                //remove key and destroy gate
                items.Remove(gate.GetComponent<GateBehaviour>().key);                
                gate.GetComponent<GateBehaviour>().DestroyGate();
                gate = null;
            }
        }
        //Debug Log for test DELETE ON BUILD
        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (string i in items)
            {
                Debug.Log("item:" + i);
            }
        }

    }
    //when hitting a trigger
    private void OnTriggerEnter(Collider other)
    {
        
        //and trigger is an item
        if (other.gameObject.tag.Equals("Item"))
        {
            stored = other.gameObject.GetComponent<Item>();
            
            
        }
        else if (other.gameObject.tag.Equals("Gate"))
        { 
            gate = other.gameObject;
            

        }
    }
    //on exit, no stored item
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Item"))
        {
            
            stored = null;
        }
        else if (other.gameObject.tag.Equals("Gate"))
        {
            
            gate = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    IEnumerator PlayWalk()
    {
        playingSound = true;
        Debug.Log("PlayWalk Called");
        aSource.PlayOneShot(walkSound);
        yield return new WaitForSeconds(walkDelayTime);
        playingSound = false;
    }
}
