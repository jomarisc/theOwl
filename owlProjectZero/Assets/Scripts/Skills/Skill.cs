using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour, ISkill
{
    // private fields

    // protected fields
    [SerializeField] protected float stamanaCost;
    [SerializeField] protected float cooldown;
    [SerializeField] protected float passiveMultiplier;
    [SerializeField] protected float currencyCost;

    // public fields
    public enum SkillType
    {
        None, Offensive, Defensive, Utility
    }

    public int requiredLevel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseSkill()
    {

    }
}
