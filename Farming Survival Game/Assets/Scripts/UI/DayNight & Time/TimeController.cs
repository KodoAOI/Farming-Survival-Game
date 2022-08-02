using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeController : MonoBehaviour
{
    [SerializeField]private Volume ppv;
    [SerializeField]private float TotalSecondInDay;
    [SerializeField] private float StartTime;
    private float TotalSecondInNight;
    private float TotalSecondADay;
    private int Day;
    private float CurrTime;
    private TimeInDay m_TimeInDay;
    private void Start() {
        TotalSecondInNight = TotalSecondInDay / 2;
        TotalSecondADay = TotalSecondInDay + TotalSecondInNight;
        CurrTime = StartTime;
    }
    private void Update() {
        CurrTime += Time.deltaTime;
        if(CurrTime > TotalSecondADay)CurrTime -= TotalSecondADay;
        
        if(CurrTime <= TotalSecondInNight / 2)
        {
            // print("Dawn");
            SetUpLight(TotalSecondInNight/2 - CurrTime, TotalSecondInNight/2);
            m_TimeInDay = TimeInDay.Morning;
        }
        else if(CurrTime >= TotalSecondInDay && CurrTime <= TotalSecondInDay + TotalSecondInNight / 2)
        {
            // print("Night");
            SetUpLight(CurrTime - TotalSecondInDay, TotalSecondInNight/2);
            m_TimeInDay = TimeInDay.Night;
        }
        else if(CurrTime <= TotalSecondADay && CurrTime >= TotalSecondInDay)
        {
            // print("MidNight");
            SetUpLight(1, 1);
        }
        else 
        {
            // print("Noon");
            SetUpLight(0, 1);
        }
        // print(CurrTime);
    }

    private void SetUpLight(float Time, float TotalTime)
    {
        float Weight = Mathf.Min(Time/TotalTime, 1f);
        ppv.weight = Weight;
    }
}

enum TimeInDay //Các buổi trong ngày
{
    Morning, Night
}