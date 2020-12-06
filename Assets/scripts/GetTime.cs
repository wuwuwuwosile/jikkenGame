using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    private int hour;
    private int minute;
    private int second;
    private int millisecond;

    float timeSpeed = 0.0f;
    Text text_timeSpeed;


    void Start()
    {
        text_timeSpeed = GetComponent<Text>();
    }

    void Update()
    {
        timeSpeed += Time.deltaTime;
        hour = (int)timeSpeed / 3600;
        minute = ((int)timeSpeed - hour * 3600) / 60;
        second = (int)timeSpeed - hour * 3600 - minute * 60;
        //millisecond = (int)((timeSpeed - (int)timeSpeed) * 1000);
        text_timeSpeed.text = string.Format("{0:D2}:{1:D2}", minute, second );
    }
}
