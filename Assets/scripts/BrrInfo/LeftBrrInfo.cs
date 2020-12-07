using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftBrrInfo : MonoBehaviour
{
    Text text_LeftBrrInfo;

    // Start is called before the first frame update
    void Start()
    {
        text_LeftBrrInfo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getLeftBrrInfo();
        Vector2 pos = (Vector2)hit.transform.position;
        float distance = hit.distance - 0.5f;
        text_LeftBrrInfo.text = pos.ToString() + "\n" + distance.ToString();
    }
}
