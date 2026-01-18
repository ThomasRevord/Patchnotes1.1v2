using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MangerBehaviour : MonoBehaviour
{
    //variables
    public float Countdown;
    public TextMeshProUGUI timeText;
    //value of scene in build index CHANGE WHEN BUILDING GAME TO MAKE IT UP TO DATE
    public int mainValue;
    public bool journalOpen;
    public GameObject Paper;
    //text for what will be on notes
    public TextMeshProUGUI noteText;
    //password texts
    public TextMeshProUGUI pass1Text;
    public TextMeshProUGUI pass2Text;
    public TextMeshProUGUI pass3Text;
    public TextMeshProUGUI pass4Text;
    //code texts
    public TextMeshProUGUI code1Text;
    public TextMeshProUGUI code2Text;
    public TextMeshProUGUI code3Text;
    public TextMeshProUGUI code4Text;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        journalOpen = false;
        pass1Text.gameObject.SetActive(false);
        pass2Text.gameObject.SetActive(false);
        pass3Text.gameObject.SetActive(false);
        pass4Text.gameObject.SetActive(false);
        code1Text.gameObject.SetActive(false);
        code2Text.gameObject.SetActive(false);
        code3Text.gameObject.SetActive(false);
        code4Text.gameObject.SetActive(false);

        //player prefs 0 is false, 1 is true
        //password items (items that are not keys)
        if (!PlayerPrefs.HasKey("Pass1"))
        {
            PlayerPrefs.SetInt("Pass1", 0);
        }
        if (!PlayerPrefs.HasKey("Pass2"))
        {
            PlayerPrefs.SetInt("Pass2", 0);
        }
        if (!PlayerPrefs.HasKey("Pass3"))
        {
            PlayerPrefs.SetInt("Pass3", 0);
        }
        if (!PlayerPrefs.HasKey("Pass4"))
        {
            PlayerPrefs.SetInt("Pass4", 0);
        }
        //Main code. will increment over time
        if (!PlayerPrefs.HasKey("Code"))
        {
            PlayerPrefs.SetInt("Code", 0);
        }
        //number of loops
        if (!PlayerPrefs.HasKey("Loop"))
        {
            PlayerPrefs.SetInt("Loop", 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //loop s
        if (Countdown > 0) Countdown -= Time.deltaTime;
        else 
        {
            Countdown = 0;
            SceneManager.LoadScene(mainValue);
            PlayerPrefs.SetInt("Loop", PlayerPrefs.GetInt("Loop") + 1);
        }
        int minutes = Mathf.FloorToInt(Countdown / 60);
        int seconds = Mathf.FloorToInt(Countdown % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes , seconds);

        //journal
        if(Input.GetKeyDown(KeyCode.J))
        {
            //if journal is open
            if (journalOpen)
            {
                Paper.SetActive(false);
                journalOpen = false;
                
                //reset passwords/codes to inactive values
                pass1Text.gameObject.SetActive(false);
                pass2Text.gameObject.SetActive(false);
                pass3Text.gameObject.SetActive(false);
                pass4Text.gameObject.SetActive(false);
                code1Text.gameObject.SetActive(false);
                code2Text.gameObject.SetActive(false);
                code3Text.gameObject.SetActive(false);
                code4Text.gameObject.SetActive(false);

            }
            //if journal is closed
            else
            {
                Paper.SetActive(true);
                journalOpen = true;
                //check if passwords/codes active and set them to their values
                if (PlayerPrefs.GetInt("Pass1") == 1)
                {
                    pass1Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Pass2") == 1)
                {
                    pass2Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Pass3") == 1)
                {
                    pass3Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Pass4") == 1)
                {
                    pass4Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Code") >= 1)
                {
                    
                    code1Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Code") >= 2)
                {
                  
                    code2Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Code") >= 3)
                {
                    
                    code3Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Code") >= 4)
                {
                    
                    code4Text.gameObject.SetActive(true);
                }
            }

        }

        //Debug code for testing player prefs DELETE THIS BEFORE GAME RELEASE
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            PlayerPrefs.SetInt("Code", PlayerPrefs.GetInt("Code") + 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(PlayerPrefs.GetInt("Code"));
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayerPrefs.SetInt("Code",0);
            PlayerPrefs.SetInt("Pass1", 0);
            PlayerPrefs.SetInt("Pass2", 0);
            PlayerPrefs.SetInt("Pass3", 0);
            PlayerPrefs.SetInt("Pass4", 0);
            PlayerPrefs.SetInt("Loop", 0);

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetInt("Pass1", 1);
            PlayerPrefs.SetInt("Pass2", 1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetInt("Pass3", 1);
            PlayerPrefs.SetInt("Pass4", 1);
        }


    }

    //method for displaying note
    public void DisplayNote()
    { 
    
    }

    //method for closing note
    public void CloseNote()
    {

    }

}
