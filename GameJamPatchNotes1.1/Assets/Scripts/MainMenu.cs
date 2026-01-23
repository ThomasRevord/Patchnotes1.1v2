// Reference https://www.youtube.com/watch?v=ivvv8kld6_0&list=PLIvwrsXuTVRCMOtbhN-oRf8U8wba-Y0t7&index=6
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider soundSlider;

    private void Start()
    {
        LoadVolume();
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

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SoundVolume", out float soundVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
    }
}
