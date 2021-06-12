using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;
    public float food = 100f;
    public float water = 100f;

    public float foodReductionMultiplyer=0.04f;
    public float waterReductionMultiplyer = 0.08f;

    // Update is called once per frame
    void Update()
    {
        food -= (foodReductionMultiplyer * Time.deltaTime);
        water -= (waterReductionMultiplyer * Time.deltaTime);
    }
}
