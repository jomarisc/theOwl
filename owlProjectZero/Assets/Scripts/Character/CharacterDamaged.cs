using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamaged : IState
{
    private readonly Character character;
    private Color characterColor;
    private Animator animator;
    private Rigidbody characterBody;
    private float damageReceived;
    private float knockBackReceived;
    private float hitstunTimer;

    public CharacterDamaged(Character c)
    {
        character = c;
        animator = c.animator;
        characterBody = c.GetComponent<Rigidbody>();
        damageReceived = 1f;
        knockBackReceived = 1f;
    }

    public CharacterDamaged(Character c, float dmg, float kb)
    {
        character = c;
        animator = c.GetComponent<Animator>();
        characterBody = c.GetComponent<Rigidbody>();
        damageReceived = dmg;
        knockBackReceived = kb;
    }

    public void Enter()
    {
        int animationLayer = -1;
        if(character is playerControl)
            animationLayer = (GlobalVars.playerHasUnlockedSuit) ? 1 : 0;
        animator.Play("Hurt", animationLayer);
        hitstunTimer = damageReceived * knockBackReceived / 20;
        if(character.TryGetComponent<SpriteRenderer>(out SpriteRenderer rend))
        {
            characterColor = character.GetComponent<SpriteRenderer>().color;
            character.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            characterColor = character.GetComponent<Renderer>().material.color;
            character.GetComponent<Renderer>().material.color = Color.red;
        }

        character.data.health -= damageReceived;
    }

    public void Exit()
    {
        if(character.TryGetComponent<SpriteRenderer>(out SpriteRenderer rend))
        {
            character.GetComponent<SpriteRenderer>().color = characterColor;
        }
        else
        {
            character.GetComponent<Renderer>().material.color = characterColor;
        }
    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        if(characterBody.velocity.x < 0)
            character.GetComponent<SpriteRenderer>().flipX = false;
        else if(characterBody.velocity.x > 0)
            character.GetComponent<SpriteRenderer>().flipX = true;
        
        hitstunTimer -= Time.deltaTime;

        if(hitstunTimer > 0f)
            return null;
        else
        {
            return character.defaultState;
        }
    }
}
