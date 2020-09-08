using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class Shield : Skill
{
    private const float DISCOLORATION_TIMER = 0.25f;
    private float discolorationTimer;
    private Color originalColor;
    [SerializeField] private float damageToNegate = 0f; // shouldn't be modified anywhere in code
    private float negatedDamage;
    private bool isDamaged;
    Shield()
    {
        type = SkillType.Defensive;
    }
    // Start is called before the first frame update
    new private void Start()
    {
        base.Start();
        discolorationTimer = 0f;
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        isDamaged = false;
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
        if(isDamaged)
        {
            discolorationTimer -= Time.deltaTime;
            if(discolorationTimer <= 0f)
            {
                discolorationTimer = 0f;
                isDamaged = false;
                gameObject.GetComponent<Renderer>().material.color = originalColor;
            }
        }
        if(isActive && negatedDamage < 0f)
            DeactivateSkill(); // Should probably have 2 kinds of skill deactivation: Forced and Manual
    }
    
    public override void UseSkill()
    {
        if(cooldown >= maxCooldown)
        {
            Physics.IgnoreLayerCollision(9, 12, true);
            Physics.IgnoreLayerCollision(9, 15, true);
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = originalColor;
            gameObject.GetComponent<Collider>().enabled = true;
            isActive = true;
            negatedDamage = damageToNegate;
        }
        else
        {
            isActive = false;
            Debug.Log("Shield is still in cooldown!");
        }
    }

    public override void DeactivateSkill()
    {
        Physics.IgnoreLayerCollision(9, 12, false);
        Physics.IgnoreLayerCollision(9, 15, false);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        isActive = false;
        cooldown = 0f;
    }

    public void GetDamaged(float damage)
    {
        discolorationTimer = DISCOLORATION_TIMER;
        Color myColor = gameObject.GetComponent<Renderer>().material.color;
        myColor.a = 0.75f;
        gameObject.GetComponent<Renderer>().material.color = myColor;
        negatedDamage -= damage;
        isDamaged = true;
    }
}
