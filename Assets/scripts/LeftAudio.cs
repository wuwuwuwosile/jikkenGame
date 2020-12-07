using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getLeftBrrInfo();
        transform.position = hit.transform.position;
    }
}
