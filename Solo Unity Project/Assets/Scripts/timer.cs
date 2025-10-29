using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System;

public class timer : MonoBehaviour
{
    public float elapsedTime;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //text.text = elapsedTime.ToString();
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        text.text = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }
}
