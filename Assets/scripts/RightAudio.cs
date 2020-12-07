using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getRightBrrInfo();
        transform.position = hit.transform.position;
    }
}
