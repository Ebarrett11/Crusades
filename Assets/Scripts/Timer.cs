using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float time;
    private float rTime;
    private int wholeTime;
    private string outputTime;
    private bool lessthan60 = true;
    public int x = 0;
    public int y = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        time += Time.deltaTime; // gets Unity Time
        rTime = Mathf.RoundToInt(time); // trim of extra digits

        //if less than ten second add a zero in front of digit
        if (rTime < 10)
        {
            outputTime = wholeTime + " :0" + rTime;
        }
        else if (rTime >= 10) //if more than ten seconds remove zero
        {
            outputTime = wholeTime + ":" + rTime;
        }

        if (rTime >= 60)//if greater than 60 add to minimum variable and restart seconds
        {
            time = 0; //restart Unity time to zero
            rTime = Mathf.RoundToInt(time);
            wholeTime++; //increase minut counter
            outputTime =  wholeTime + ":" + rTime;

        }

    }

    void OnGUI()
    {
        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 30;
        textStyle.normal.textColor = Color.white;
        if(wholeTime > 2)
        {
            textStyle.normal.textColor = Color.red;
        }
        GUI.Label(new Rect(x, y, 300, 25), outputTime, textStyle);
    }

}//end of class