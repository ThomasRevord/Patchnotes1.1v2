using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class MangerBehaviour : MonoBehaviour
{
    //variables
    public float Countdown;
    public TextMeshProUGUI timeText;
    public float delaytime;
    public GameObject lightningAnimation;
    public bool timeStop;
    //value of scene in build index CHANGE WHEN BUILDING GAME TO MAKE IT UP TO DATE
    public int mainValue = 1;
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
    public int pass3Value;
    public GameObject tutorialText;
    public GameObject getText;
    public float cutsceneLength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //made UI invisible
        journalOpen = false;
        timeStop = false;
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
        //Main code prefs
        if (!PlayerPrefs.HasKey("Code1"))
        {
            PlayerPrefs.SetInt("Code1", 0);
        }
        if (!PlayerPrefs.HasKey("Code2"))
        {
            PlayerPrefs.SetInt("Code2", 0);
        }
        if (!PlayerPrefs.HasKey("Code3"))
        {
            PlayerPrefs.SetInt("Code3", 0);
        }
        if (!PlayerPrefs.HasKey("Code4"))
        {
            PlayerPrefs.SetInt("Code4", 0);
        }
        //number of loops
        if (!PlayerPrefs.HasKey("Loop"))
        {
            PlayerPrefs.SetInt("Loop", 0);
        }
        //handle password3
        if (PlayerPrefs.GetInt("Loop") >= pass3Value)
        {
            PlayerPrefs.SetInt("Pass3", 1);
        }
        //handle tutorial text
        if (PlayerPrefs.GetInt("Loop") >= 1)
        {
            tutorialText.SetActive(false);
        }
        MusicManager.Instance.PlayMusic("Game");
    }

    // Update is called once per frame
    void Update()
    {
        //loop s
        if (Countdown > 0 && !timeStop) Countdown -= Time.deltaTime;
        if(Countdown <= 0)
        {
            Countdown = 0;
            StartCoroutine(NewLoop());
          
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
                if (PlayerPrefs.GetInt("Code1") == 1)
                {
                    
                    code1Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Code2") == 1)
                {
                  
                    code2Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Code3") == 1)
                {
                    
                    code3Text.gameObject.SetActive(true);
                }
                if (PlayerPrefs.GetInt("Code4") == 1)
                {
                    
                    code4Text.gameObject.SetActive(true);
                }
            }
            getText.SetActive(false);

        }

        //Debug code for testing player prefs DELETE THIS BEFORE GAME RELEASE
        /*
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
            PlayerPrefs.SetInt("Code1",0);
            PlayerPrefs.SetInt("Code2", 0);
            PlayerPrefs.SetInt("Code3", 0);
            PlayerPrefs.SetInt("Code4", 0);
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
            PlayerPrefs.SetInt("Code1", 1);
            PlayerPrefs.SetInt("Code2", 1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetInt("Code3", 1);
            PlayerPrefs.SetInt("Code4", 1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Loop" + PlayerPrefs.GetInt("Loop"));
        }
        */


    }

    //method for displaying note
    public void DisplayNote()
    { 
    
    }

    //method for closing note
    public void CloseNote()
    {

    }

    IEnumerator NewLoop()
    {
        lightningAnimation.SetActive(true);
        yield return new WaitForSeconds(delaytime);
        SceneManager.LoadScene(mainValue);
        PlayerPrefs.SetInt("Loop", PlayerPrefs.GetInt("Loop") + 1);
    }

    public void FinalCutscene()
    {
        timeStop = true;
        MusicManager.Instance.StopMusic();
        SoundManager.PlaySound("FinalAudio");
        Debug.Log("FinalCutscene trigger");
        StartCoroutine(finalLoop());
    }

    IEnumerator finalLoop()
    {
        yield return new WaitForSeconds(cutsceneLength);
        lightningAnimation.SetActive(true);
        yield return new WaitForSeconds(delaytime);
        SceneManager.LoadScene(0);
    }
   
}
