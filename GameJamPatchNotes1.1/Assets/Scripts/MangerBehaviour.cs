using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MangerBehaviour : MonoBehaviour
{
    //variables
    public float Countdown;
    public TextMeshProUGUI timeText;
    public int mainValue;
    public TextMeshProUGUI updateText;
    public bool journalOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        journalOpen = false;

        //player prefs 0 is false, 1 is true
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
            Debug.Log("LOOP");
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

            }
            //if journal is closed
            else
            { 
            
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
            PlayerPrefs.DeleteKey("Code");
        }

    }

 
}
