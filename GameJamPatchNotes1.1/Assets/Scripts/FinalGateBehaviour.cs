using UnityEngine;

public class FinalGateBehaviour : MonoBehaviour
{
    public GameObject interactable;
    public bool touchingPlayer;
    public GameObject manager;
    public bool cutCalled;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        touchingPlayer = false;
        cutCalled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer && cutCalled == false)
        {
            CheckCode();
            cutCalled = true;
        }
    }

    public void showImage()
    {
        if(!cutCalled) interactable.SetActive(true);
    }
    public void hideImage()
    {
        interactable.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        showImage();
        if (other.tag == "Player")
        {
            touchingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hideImage();
        touchingPlayer = false;

    }


    public void CheckCode()
    {
        Debug.Log("Check Code called");
        //check if player has all code
        if (PlayerPrefs.GetInt("Code1") == 1 && PlayerPrefs.GetInt("Code2") == 1 && PlayerPrefs.GetInt("Code3") == 1 && PlayerPrefs.GetInt("Code4") == 1)
        {
            interactable.SetActive(false);
            manager.gameObject.GetComponent<MangerBehaviour>().FinalCutscene();
        }
    }
}
