using System.Collections;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static SoundEffect Instance;

    public AudioClip eatSound;
    public AudioClip beEatSound;
    public AudioClip crashSound;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeEatSound()
    {
        MakeSound(eatSound);
    }

    public void MakeBeEatSound()
    {
        MakeSound(beEatSound);
    }

    public void MakeCrashSound()
    {
        MakeSound(crashSound);
    }


    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
