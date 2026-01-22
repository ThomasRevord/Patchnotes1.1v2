using UnityEngine;

public class ComboGate : MonoBehaviour
{
    public GameObject interactable;
    public bool touchingPlayer;
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer == true)
        {
            CheckLocks();
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
        touchingPlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hideImage();
        touchingPlayer = false;
        
    }

    public void CheckLocks()
    {
        if (lock1.GetComponent<LockBehaviour>().CheckLock() == true && lock2.GetComponent<LockBehaviour>().CheckLock() == true && lock3.GetComponent<LockBehaviour>().CheckLock() == true)
        {
            interactable.SetActive(false);
            Destroy(gameObject);
        }
    }

}
