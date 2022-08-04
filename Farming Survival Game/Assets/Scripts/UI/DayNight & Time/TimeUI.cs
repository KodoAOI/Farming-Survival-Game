using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TimeController m_TimeController;
    [SerializeField] private TextMeshProUGUI m_Day;
    [SerializeField] private TextMeshProUGUI m_Time;
    private int hour, minute;
    // Update is called once per frame
    void Update()
    {
        m_Day.text = "Day: " + m_TimeController.GetDay().ToString();
        hour = m_TimeController.GetHour();
        minute = m_TimeController.GetMinute();
        m_Time.text = hour.ToString() + ":" + minute.ToString();
    }
}
