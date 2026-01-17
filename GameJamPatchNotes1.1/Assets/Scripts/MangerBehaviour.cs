using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MangerBehaviour : MonoBehaviour
{
    //variables
    public float Countdown;
    public TextMeshProUGUI timeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(Countdown / 60);
        int seconds = Mathf.FloorToInt(Countdown % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes , seconds);
    }

 
}
