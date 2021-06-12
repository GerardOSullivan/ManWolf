using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    private Image waterBar;
    [HideInInspector]
    public float currentWater;
    private float maxWater = 100f;
    PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        //Get Players stats
        waterBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWater = player.water;
        waterBar.fillAmount = currentWater / maxWater;
    }
}
