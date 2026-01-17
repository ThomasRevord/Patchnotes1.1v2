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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement (using old input system)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
       //rotation (using old input system)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(rotation * rotateSpeed * Time.deltaTime * -1);
        }
        if (Input.GetKeyDown(KeyCode.E) && stored != null)
        {
            //add to inventory
            items.Add(stored.GetItem());
        }
    }
    //when hitting a trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");
        //and trigger is an item
        if (other.gameObject.tag.Equals("Item"))
        {
            stored = other.gameObject.GetComponent<Item>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                //add to inventory
                items.Add(stored.GetItem());
            }
            stored.showImage();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stored.hideImage();
        stored = null;
    }
}
