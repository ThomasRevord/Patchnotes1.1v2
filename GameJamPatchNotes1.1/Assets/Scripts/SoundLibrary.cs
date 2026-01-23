// Reference https://www.youtube.com/watch?v=jEoobucfoL4&list=PLIvwrsXuTVRCMOtbhN-oRf8U8wba-Y0t7&index=5
using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string name;
    public AudioClip[] clips;
}

public class SoundLibrary : MonoBehaviour
{
    public SoundEffect[] soundEffects;
    
    public AudioClip GetClipFromName(string name)
    {
        foreach (var soundEffects in soundEffects)
        {
            if (soundEffects.name == name)
            {
                return soundEffects.clips[Random.Range(0, soundEffects.clips.Length)];
            }
        }

        return null;
    }
}
