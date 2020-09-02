using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamaged : IState
{
    private readonly Character character;
    private Color characterColor;
    private float damageReceived;
    private float knockBackReceived;
    private float hitstunTimer;

    public CharacterDamaged(Character c)
    {
        character = c;
        damageReceived = 1f;
        knockBackReceived = 1f;
    }

    public CharacterDamaged(Character c, float dmg, float kb)
    {
        character = c;
        damageReceived = dmg;
        knockBackReceived = kb;
    }

    public void Enter()
    {
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

        // character.data.health -= damageReceived;
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
        hitstunTimer -= Time.deltaTime;

        if(hitstunTimer > 0f)
            return null;
        else
        {
            return character.defaultState;
        }
    }
}
