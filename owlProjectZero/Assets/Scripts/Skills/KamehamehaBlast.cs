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
    
    public KamehamehaBlast(Character c, Attack b, SpriteRenderer br)
    {
        user = c;
        blast = b;
        hitbox = b.GetComponent<CapsuleCollider>();
        beamSprite = b.GetComponentInChildren<SpriteRenderer>();
        beamRootSprite = br;
    }

    public void Enter()
    {
        blast.gameObject.SetActive(true);
        beamRootSprite.gameObject.SetActive(true);
        user.Attack(blast.gameObject);
        // user.Attack(); // Should change attack method to take in
                          // a GameObject to change positions

        // Should have a way to disable listening for useActiveSkill input

    }

    public void Exit()
    {
        hitbox.center = Vector3.zero;
        hitbox.height = 2f;
        beamSprite.transform.localPosition = Vector3.zero;
        beamSprite.transform.localScale = new Vector3(1f, 6f, 1f);
        beamRootSprite.transform.localPosition = Vector3.zero;
        if(blast.gameObject.activeInHierarchy)
        {
            blast.gameObject.SetActive(false);
            beamRootSprite.gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        Vector3 offset = new Vector3(0.1f, 0f, 0f);
        Vector3 shiftedCenter = (user.data.isFacingRight) ? hitbox.center + offset : hitbox.center - offset;
        hitbox.center = shiftedCenter;
        beamSprite.transform.localPosition = shiftedCenter;

        float newHeight = (user.data.isFacingRight) ? shiftedCenter.x * 2 + 1 : shiftedCenter.x * 2 - 1;
        hitbox.height = newHeight;
        beamSprite.transform.localScale = new Vector3(newHeight * 3, 6f, 1f);
        offset = new Vector3(newHeight / 2, 0f, 0f);
        beamRootSprite.transform.localPosition = (user.data.isFacingRight) ? shiftedCenter + offset : shiftedCenter - offset;
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
