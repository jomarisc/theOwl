using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    None, Offensive, Defensive, Utility
}

public abstract class Skill : MonoBehaviour, ISkill
{
    // private fields

    // protected fields
    [SerializeField] protected float stamanaCost;
    [SerializeField] protected float maxCooldown;
    protected float cooldown;
    [SerializeField] protected float passiveMultiplier;
    [SerializeField] protected float currencyCost;

    // public fields
    public SkillType type;

    public int requiredLevel;
    public bool isActive;
    public float usageCost { get; protected set; }


    // Start is called before the first frame update
    protected void Start()
    {
        cooldown = maxCooldown;
        Debug.Log("cooldown" + cooldown);
        isActive = false;
        usageCost = stamanaCost;
        Debug.Log("S cost: " + usageCost);
    }

    // Update is called once per frame
    protected void Update()
    {
        if(isActive)
        {
            if(cooldown > 0f)
                cooldown -= Time.deltaTime;
            else
            {
                isActive = false;
                DeactivateSkill();
            }
        }
        else
        {
            if(cooldown < maxCooldown)
                cooldown += Time.deltaTime;
            else if(cooldown > maxCooldown)
                cooldown = maxCooldown;
        }
    }

    public abstract void UseSkill();
    public abstract void DeactivateSkill();
}
