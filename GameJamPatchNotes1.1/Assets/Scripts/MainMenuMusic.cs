using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlayMusic("Main Menu", 0.5f);
    }
}
