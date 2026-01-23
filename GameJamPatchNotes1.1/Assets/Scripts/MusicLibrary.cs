// Reference https://www.youtube.com/watch?v=Q-bKHocRvE0&list=PLIvwrsXuTVRCMOtbhN-oRf8U8wba-Y0t7&index=4
using UnityEngine;

[System.Serializable]
public class MusicTrack
{
    public string trackName;
    public AudioClip clip;
}

public class MusicLibrary : MonoBehaviour
{
    public MusicTrack[] tracks;

    public AudioClip GetClipByName(string name)
    {
        foreach (var track in tracks)
        {
            if (track.trackName == name)
            {
                return track.clip;
            }
        }
        return null;
    }
}
