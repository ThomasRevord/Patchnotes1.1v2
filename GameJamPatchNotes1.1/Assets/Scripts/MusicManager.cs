// Reference https://www.youtube.com/watch?v=Q-bKHocRvE0&list=PLIvwrsXuTVRCMOtbhN-oRf8U8wba-Y0t7&index=4
using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField]
    private MusicLibrary musicLibrary;
    [SerializeField]
    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string trackName, float fadeDuration = 0.5f)
    {
        StartCoroutine(AnimateMusicCrossfade(musicLibrary.GetClipByName(trackName), fadeDuration));
    }

    // Music fade in/out
    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration = 0.5f)
    {
        float percent = 0f;
        // Fade out
        while (percent < 1f)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent);
            yield return null;
        }

        musicSource.clip = nextTrack;
        musicSource.Play();

        percent = 0f;

        // Fade in
        while (percent < 1f)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }
    }

    public void StopMusic()
    {
        StartCoroutine(StopMusic(0.5f));
    }

    IEnumerator StopMusic(float fadeDuration = 0.5f)
    {
        float percent = 0f;
        // Fade out
        while (percent < 1f)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent);
            yield return null;
        }

        musicSource.Stop();
    }
}
