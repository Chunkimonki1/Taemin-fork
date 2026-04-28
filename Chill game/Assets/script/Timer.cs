using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingtime;
    // Update is called once per frame
    void Update()
    {
        if (remainingtime > 0)
        {
            remainingtime += Time.deltaTime;
        }
        else if (remainingtime < 15)
        {

        }
        int minutes = Mathf.FloorToInt(remainingtime / 60);
        int seconds = Mathf.FloorToInt(remainingtime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}