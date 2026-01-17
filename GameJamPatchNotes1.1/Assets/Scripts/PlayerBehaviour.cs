using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //variables
    public float speed;
    public Rigidbody rigid;
    public Vector3 rotation;
    public float rotateSpeed;
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
    }
}
