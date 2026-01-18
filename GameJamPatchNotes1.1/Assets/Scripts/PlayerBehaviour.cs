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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement (using old input system)
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
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
        if (Input.GetKeyDown(KeyCode.E) && stored != null)
        {
            //add to inventory
            items.Add(stored.GetItem());
            stored.hideImage();
            stored.DestroyItem();
            //clear stored
            stored = null;
        }
        else if (Input.GetKeyDown(KeyCode.E) && gate != null)
        {
            Debug.Log("GateE");
            //check if player has key
            bool hasItem = gate.GetComponent<GateBehaviour>().CheckKey(items);
            Debug.Log(hasItem);
            //if they do
            if (hasItem == true)
            {
                //remove key and destroy gate
                items.Remove(gate.GetComponent<GateBehaviour>().key);                
                gate.GetComponent<GateBehaviour>().DestroyGate();
                gate = null;
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
        /*
        if (other.gameObject.tag.Equals("Gate"))
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("GateE");
                //check if player has key
                bool hasItem = gate.GetComponent<GateBehaviour>().CheckKey(items);
                Debug.Log(hasItem);
                //if they do
                if (hasItem == true)
                {
                    //remove key and destroy gate
                    items.Remove(gate.GetComponent<GateBehaviour>().key);
                    Destroy(other);
                }
            }

        }*/
    }
}
