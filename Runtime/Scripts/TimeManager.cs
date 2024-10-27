using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Transform sun;
    [SerializeField] private Transform moon;
    
    [Range(0, 360)]
    [SerializeField] private float longitude;
    [Range(-90, 90)]
    [SerializeField] private float latitude;
    
    private int minutes;
    private int hours;
    private int days;
    private float tempSecond;

    private void Update()
    {
        tempSecond += Time.deltaTime;
        if (tempSecond >= 1)
        {
            tempSecond = 0;
            minutes++;
            OnTimeChanged();
        }
    }
    
    public void SetTime(int days, int hours, int minutes)
    {
        this.days = days;
        this.hours = hours;
        this.minutes = minutes;
    }

    private void OnTimeChanged()
    {
        
    }
}