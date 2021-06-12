using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    [SerializeField]
    public Light sun;

    [SerializeField]
    private float minutesInTheFullDay = 2f;

    [SerializeField]
    private float intensityMultiplyer = 0.5f;

    [Range(0, 1)]
    [SerializeField]
    private float currentTimeOfDay = 0;
    private float timeMultiplyer = 1f;
    private float sunInitialIntensity;

    void Start()
    {
        sunInitialIntensity = sun.intensity;
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / (minutesInTheFullDay*60)) * timeMultiplyer;

        if(currentTimeOfDay >=1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        if(currentTimeOfDay <= 0.23f || currentTimeOfDay>= 0.75f)
        {
            intensityMultiplyer = 0;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplyer = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1/0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplyer = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplyer;
    }



}
