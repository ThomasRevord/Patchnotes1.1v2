using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlayMusic("Main Menu");
    }

    public void Play()
    {
        MusicManager.Instance.PlayMusic("Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Quit");
    }
}
