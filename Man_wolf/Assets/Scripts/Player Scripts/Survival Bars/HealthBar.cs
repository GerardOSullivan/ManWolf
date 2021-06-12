using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    [HideInInspector]
    public float currentHealth;
    private float maxHealth = 100f;
    PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        //Get Players stats
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.health;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
