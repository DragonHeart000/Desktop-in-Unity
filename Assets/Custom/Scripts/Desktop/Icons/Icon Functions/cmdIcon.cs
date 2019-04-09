using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmdIcon : MonoBehaviour, IconFunctionInterface
{

    private float lastClick;
    private float doubleClickSpeed = 1f;

    private int clicks;

    public void onClick()
    {
        if (clicks == 1)
        {
            if (Time.time <= lastClick + doubleClickSpeed)
            {
                clicks = 0;
                Debug.Log("Double click");
            }
            else
            {
                lastClick = Time.time;
            }
        }
        else
        {
            clicks++;
            lastClick = Time.time;
        }
    }
}
