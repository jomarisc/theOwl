using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehamehaBlast : IState
{
    private readonly Character user;
    private Attack blast;
    private CapsuleCollider hitbox;
    private SpriteRenderer beamSprite;
    private SpriteRenderer beamRootSprite;
    private float growthRate;
    
    public KamehamehaBlast(Character c, Attack b, SpriteRenderer br, float gr)
    {
        user = c;
        blast = b;
        hitbox = b.GetComponentInChildren<CapsuleCollider>();
        beamSprite = b.GetComponentInChildren<SpriteRenderer>();
        beamRootSprite = br;
        growthRate = gr;
    }

    public void Enter()
    {
        int animationLayer = (GlobalVars.playerHasUnlockedSuit) ? 1 : 0;
        user.animator.Play("KamehamehaBlast", animationLayer);
        blast.gameObject.SetActive(true);
        beamRootSprite.gameObject.SetActive(true);
        float direction = (user.data.isFacingRight) ? 1 : -1;
        beamSprite.transform.localPosition = new Vector3(direction * 2.4f, 0, 0); // 2.4f comes from the local x position
        beamSprite.size = new Vector2(direction * 1f, 1.28f);
        beamRootSprite.transform.localPosition = new Vector3(direction * 1.3f, 0, 0); // 1.3f comes from the local x position
        beamRootSprite.flipX = user.data.isFacingRight;
        user.Attack(blast.gameObject);
        hitbox.center = new Vector3(direction * 0.75f, 0, 0);
        // user.Attack(); // Should change attack method to take in
                          // a GameObject to change positions

        // Should have a way to disable listening for useActiveSkill input

    }

    public void Exit()
    {
        hitbox.center = Vector3.zero;
        hitbox.height = 3.5f;
        // beamSprite.transform.localPosition = Vector3.zero;
        // beamSprite.transform.localScale = new Vector3(1f, 1.5f, 1f);
        // beamSprite.size = new Vector2(1f, 1.28f);
        // beamRootSprite.transform.localPosition = Vector3.zero;
        beamRootSprite.gameObject.SetActive(false);
        blast.gameObject.GetComponentInParent<Kamehameha>().DeactivateSkill();
        if(blast.gameObject.activeInHierarchy)
        {
            blast.gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        Vector3 offset = new Vector3(growthRate, 0f, 0f);
        Vector3 shiftedCenter = (user.data.isFacingRight) ? hitbox.center + offset : hitbox.center - offset;
        hitbox.center = shiftedCenter;
        // beamSprite.transform.localPosition = shiftedCenter;

        float formula = hitbox.height + 2 * growthRate;
        hitbox.height = formula;
        // beamSprite.transform.localScale = new Vector3(formula * 3, 1.5f, 1f);
        int growthDirection = (user.data.isFacingRight) ? 1 : -1;
        formula = beamSprite.size[0] + 2 * growthRate * growthDirection;
        beamSprite.size = new Vector2(formula, 1.28f);
        shiftedCenter = beamSprite.transform.localPosition + offset * growthDirection;
        beamSprite.transform.localPosition = shiftedCenter;
        // offset = new Vector3(formula / 2, 0f, 0f);

        // Code for the beam tip
        // shiftedCenter = beamRootSprite.transform.localPosition + 2 * offset * growthDirection;
        // beamRootSprite.transform.localPosition = shiftedCenter;
    }

    public IState Update()
    {
        if(blast.gameObject.activeInHierarchy)
            return null;
        return new PlayerIdle((playerControl) user); // Should refactor idle
                                                     // state to take in a
                                                     // generic character type
    }
}
