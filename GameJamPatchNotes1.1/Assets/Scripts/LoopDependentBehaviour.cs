using UnityEngine;

public class LoopDependentBehaviour : MonoBehaviour
{
    public int loopThresh;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt("Loop") < loopThresh)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
