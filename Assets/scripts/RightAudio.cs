using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAudio : MonoBehaviour
{
    private bool mode = false;
    private AudioSource m_AudioSource;
    public AudioClip[] audios;
    private float default_pitch;
    // Start is called before the first frame update
    void Start()
    {
        mode = GameManager.mode;
        m_AudioSource = GetComponent<AudioSource>();
        default_pitch = m_AudioSource.pitch;
        if (!mode) 
        {
            m_AudioSource.clip = audios[0];
            m_AudioSource.Play();
        }
        else {
            m_AudioSource.clip = audios[1];
            // m_AudioSource.spatialBlend = 0.0f;
            m_AudioSource.panStereo = 1.0f;
            m_AudioSource.loop = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getRightBrrInfo();
        float distance_up = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getUpBrrInfo().distance - 0.5f;
        float distance_down = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getDownBrrInfo().distance - 0.5f;
        if (System.Convert.ToInt32(distance_up) == 0 && System.Convert.ToInt32(distance_down) == 0) m_AudioSource.pitch = default_pitch;
        else m_AudioSource.pitch = (0.4f / (distance_up + distance_down) * distance_down + 0.8f ) * default_pitch;
        transform.position = hit.transform.position;
        if (mode) {
            float distance = hit.distance - 0.5f;
            if (Input.GetKeyDown("space"))
            {
                // Debug.Log("Right" + distance);
                playByDis(distance);
            }
        }
        
    }

    void playByDis(float distance)
    {
        switch (System.Convert.ToInt32(distance))
            {
                case 0:
                    m_AudioSource.PlayDelayed(0.1f);
                    break;
                case 1:
                    m_AudioSource.PlayDelayed(0.28f);
                    break;
                case 2:
                    m_AudioSource.PlayDelayed(0.46f);
                    break;
                case 3:
                    m_AudioSource.PlayDelayed(0.64f);
                    break;
                case 4:
                    m_AudioSource.PlayDelayed(0.82f);
                    break;
                case 5:
                    m_AudioSource.PlayDelayed(1.0f);
                    break;
                default:
                    Debug.Log(distance);
                    break;
            }
    }
}
