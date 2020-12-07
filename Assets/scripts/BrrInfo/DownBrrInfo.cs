using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownBrrInfo : MonoBehaviour
{
    Text text_DownBrrInfo;

    // Start is called before the first frame update
    void Start()
    {
        text_DownBrrInfo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getDownBrrInfo();
        Vector2 pos = (Vector2)hit.transform.position;
        float distance = hit.distance - 0.5f;
        text_DownBrrInfo.text = pos.ToString() + "\n" + distance.ToString();
    }
}
