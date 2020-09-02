using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class Shield : Skill
{
    Shield()
    {
        type = SkillType.Defensive;
    }
    // Start is called before the first frame update
    new private void Start()
    {

    }

    // Update is called once per frame
    new private void Update()
    {
        
    }
    
    public override void UseSkill()
    {
        if(cooldown >= maxCooldown)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            isActive = true;
        }
        else
        {
            isActive = false;
            Debug.Log("Shield is still in cooldown!");
        }
    }

    public override void DeactivateSkill()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
