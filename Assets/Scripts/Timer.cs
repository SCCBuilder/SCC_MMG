using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //duration
    public float totalSeconds = 0.0f;

    private float elapsedSeconds = 0.0f;
    private bool running = false;
    public bool started = false;

    public void Run()
    {
        //Debug.Log("timer is running");
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    //public 

    public bool Finished
    {
        get { return started && !running; }
    }

    public bool Running
    {
        get { return running; }
    }

    // Update is called once per frame
    void Update()
    {
     if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds>= totalSeconds)
            {
                //Debug.Log("totalseconds" + totalSeconds);
                //Debug.Log("elapsedseconds" + elapsedSeconds);
                running = false;
                //Debug.Log("running is" + running);
            }
        }   
    }
}
