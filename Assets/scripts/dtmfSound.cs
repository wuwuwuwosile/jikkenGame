using UnityEngine;

public class dtmfSound : MonoBehaviour
{
    public static dtmfSound Instance;

    public AudioClip access_2;
    public AudioClip access_3;
    public AudioClip access_4;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void Access_2_Sound()
    {
        MakeSound(access_2);
    }

    public void Access_3_Sound()
    {
        MakeSound(access_3);
    }

    public void Access_4_Sound()
    {
        MakeSound(access_4);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
