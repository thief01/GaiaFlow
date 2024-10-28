using System;
using UnityEngine;

[ExecuteInEditMode]
public class TimeManager : MonoBehaviour
{
    private readonly Vector3 MORNING_SUN = new Vector3(-1, 0, 0);
    private readonly Vector3 NOON_SUN = new Vector3(0, 0, 1);
    private readonly Vector3 EVENING_SUN = new Vector3(1, 0, 0);
    
    [SerializeField] private Material skybox;
    [SerializeField] private Transform sun;
    [SerializeField] private Transform moon;
    [SerializeField] private Light sunLight;
    [SerializeField] private Gradient sunColor;
    [SerializeField] private float sunIntensity;
    
    //[Serializable] private 
    
    [Range(0, 360)]
    [SerializeField] private float longitude;
    [Range(-90, 90)]
    [SerializeField] private float latitude;

    [Range(0, 1440)]
    [SerializeField] private float time;
    
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
        
        skybox.SetVector("_SunDirection", sun.forward);
        skybox.SetVector("_MoonDirection", moon.forward);
        skybox.SetVector("_MoonRightDirection", moon.right);
        skybox.SetVector("_MoonUpDirection", moon.up);
        skybox.SetColor("_SunColor", sunColor.Evaluate(time / 1440) * sunIntensity);

        UpdateSun();
    }
    
    public void SetTime(int days, int hours, int minutes)
    {
        this.days = days;
        this.hours = hours;
        this.minutes = minutes;
    }
    
    private void UpdateSun()
    {
        float angle = 180f / 1440f * time;
        sun.rotation = Quaternion.Euler(angle, 0, 0);
        sunLight.colorTemperature = 1000 + 1000 * Mathf.Cos(angle * Mathf.Deg2Rad);
    }

    private void OnTimeChanged()
    {
        
    }
}