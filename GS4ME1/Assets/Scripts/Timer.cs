using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float timer;
    private float timerminutes;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TimeSpan time = TimeSpan.FromMilliseconds(timer);
        text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
    }
}
