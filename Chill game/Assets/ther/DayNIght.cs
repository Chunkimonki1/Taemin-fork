using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DayNIght : MonoBehaviour
{
    public int round;


    public float time;
    private Material sky;
    public Transform sun;
    public float daySpeed;

    public float timeOfDay;
    public bool day;

    private float angle=90;
    private bool rotated1;
    private bool rotated2;

    public RectTransform DayNightIndicator;

    public void Awake()
    {
        sky = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay+=Time.deltaTime*daySpeed;
        //timeOfDay = time;

        if (timeOfDay > 24)
        {
            timeOfDay=0;
            rotated1 = false;
            rotated2 = false;
        }

        sun.transform.Rotate(Time.deltaTime*daySpeed*15, 0, 0);

        
        if (timeOfDay > 12)
        {
            if (rotated1 == false)
            {
                angle-=90;
                rotated1 = true;
                day=false;
            }
        } 
        else
        {
            if (rotated2 == false)
            {
                round++;
                angle-=90;
                rotated2 = true;
                day=true;
            }
        }
        DayNightIndicator.rotation = Quaternion.Lerp(DayNightIndicator.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime*10);
    }
}


