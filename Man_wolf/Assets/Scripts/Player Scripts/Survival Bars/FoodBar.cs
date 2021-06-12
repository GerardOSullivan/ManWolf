using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    private Image foodBar;
    [HideInInspector]
    public float currentFoodLevel;
    private float maxFood = 100f;
    PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        //Get Players stats
        foodBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        currentFoodLevel = player.food;
        foodBar.fillAmount = currentFoodLevel / maxFood;
    }
}
