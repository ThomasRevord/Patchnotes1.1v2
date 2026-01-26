using UnityEngine;

public class ComboGate : MonoBehaviour
{
    public GameObject interactable;
    public GameObject touchingPlayer;
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public AudioClip openSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        touchingPlayer = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer != null)
        {
            CheckLocks();
        }
    }

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

    public void CheckLocks()
    {
        if (lock1.GetComponent<LockBehaviour>().CheckLock() == true && lock2.GetComponent<LockBehaviour>().CheckLock() == true && lock3.GetComponent<LockBehaviour>().CheckLock() == true)
        {
            SoundManager.PlaySound("Door");
            interactable.SetActive(false);
            Destroy(gameObject);
        }
    }

}
