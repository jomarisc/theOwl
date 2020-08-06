using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using CodeMonkey;

public class HealthbarController : MonoBehaviour
{
    //public EventHandler OnHealthChanged;
    public Image healthBar;
    public float currentHealth;
    public float healthMax;

    //public class OnHealthChangedEventArgs : EventArgs
    //{
    // Define fields that are needed
    //public float amountChanged;

    //}

    void Start()
    {
        GameObject player = GameObject.Find("player");
        playerControl playerScript = player.GetComponent<playerControl>();
        //playerScript.health -= 0f;
        currentHealth = playerScript.health;
        HealthbarSystem healthSystem = new HealthbarSystem(currentHealth);
        Debug.Log("Health: " + healthSystem.GetHealth());

        /*
        CMDebug.ButtonUI(new Vector2(100, 100), "damage", () =>
        {
            healthSystem.Damage(2);
            Debug.Log("Damaged: " + healthSystem.GetHealth());
        });

        CMDebug.ButtonUI(new Vector2(-100, 100), "heal", () =>
        {
            healthSystem.Heal(2);
            Debug.Log("Healed: " + healthSystem.GetHealth());
        });
        */
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // Ensures that health does not go below 0
        healthBar.fillAmount = currentHealth / healthMax;
        if (currentHealth < 0) currentHealth = 0;
        Debug.Log("Current Health: " + currentHealth);
        
    }

    /*
    public void Damage(int damageAmount) 
    {
        playerScript.Health -= damageAmount;
        if (playerScript.Health < 0) playerScript.Health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(int healAmount)
    {
        playerScript.Health += healAmount;
        if (playerScript.Health > healthMax) playerScript.Health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
    */
}
