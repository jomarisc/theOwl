using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarSystem
{
    public Image healthBar;
    private float health;
    private float healthMax;

    public HealthbarSystem(float healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public float GetHealth()
    {
        return health;
    }
    
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        // Ensures that health does not go below 0
        healthBar.fillAmount = health / healthMax;
        if (health < 0) health = 0;
    }
    
    public void Heal(int healAmount)
    {
        health += healAmount;
        // Ensures that health does go above max
        if (health > healthMax) health = healthMax;
    }
}
