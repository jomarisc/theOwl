using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class Shield : Skill
{
    [SerializeField]
    private float damageToNegate = 0f; // shouldn't be modified anywhere in code
    private float negatedDamage;
    Shield()
    {
        type = SkillType.Defensive;
    }
    // Start is called before the first frame update
    new private void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
        if(isActive && negatedDamage < 0f)
            DeactivateSkill(); // Should probably have 2 kinds of skill deactivation: Forced and Manual
    }
    
    public override void UseSkill()
    {
        if(cooldown >= maxCooldown)
        {
            Physics.IgnoreLayerCollision(9, 12, true);
            gameObject.GetComponent<Renderer>().enabled = true;
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
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        isActive = false;
        cooldown = 0f;
    }

    public void GetDamaged(float damage)
    {
        negatedDamage -= damage;
    }
}
