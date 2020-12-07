using UnityEngine;

public class dtmfSound : MonoBehaviour
{
    AudioSource m_AudioSource;
    public AudioClip access_2;
    public AudioClip access_3;
    public AudioClip access_4;

    private int path = 0;

    public void Start()
    {
        Debug.Log("1");
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();
    }

    public void Update()
    {
        int pathCount = GameObject.Find("player").GetComponent<PlayerMoveAzu>().refreshPath();
        if (path != pathCount)
        {
            switch (pathCount)
            {
                case 2: {
                    Access_2_Sound();
                    break;
                }
                case 3: {
                    Access_3_Sound();
                    break;
                }
                case 4: {
                    Access_4_Sound();
                    break;
                }
                default:break;
            }
            Debug.Log(pathCount);
            path = pathCount;
        }
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
        m_AudioSource.clip = originalClip;
        m_AudioSource.Play();
    }
}
