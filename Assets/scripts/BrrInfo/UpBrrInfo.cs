using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpBrrInfo : MonoBehaviour
{
    Text text_UpBrrInfo;

    // Start is called before the first frame update
    void Start()
    {
        text_UpBrrInfo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = GameObject.Find("player").GetComponent<PlayerMoveAzu>().getUpBrrInfo();
        Vector2 pos = (Vector2)hit.transform.position;
        float distance = hit.distance - 0.5f;
        text_UpBrrInfo.text = pos.ToString() + "\n" + System.Convert.ToInt32(distance).ToString();
    }
}
