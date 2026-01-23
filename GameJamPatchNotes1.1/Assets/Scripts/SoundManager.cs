// Reference https://www.youtube.com/watch?v=jEoobucfoL4&list=PLIvwrsXuTVRCMOtbhN-oRf8U8wba-Y0t7&index=5
// Reference https://www.youtube.com/watch?v=g5WT91Sn3hg
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private SoundLibrary soundLibrary;
    [SerializeField]
    private AudioSource soundSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlaySound(string soundName)
    {
        instance.soundSource.PlayOneShot(instance.soundLibrary.GetClipFromName(soundName));
    }
}
