using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : HeavyEnemy
{
    [Header("Other")]
    public GameObject slamHitbox;
    public Transform spritesParent;
    void OnEnable()
    {
        if(myState == null)
        {
            defaultState = new MiniBossIdle(this);
            myState = defaultState;
        }
    }

    public override void FlipSprite()
    {
        // Empty to avoid using the parent's version
    }

    public void TurnAround()
    {
        Vector3 newLocalScale = spritesParent.localScale;
        newLocalScale.x = (data.isFacingRight) ? -1 : 1;
        spritesParent.localScale = newLocalScale;
    }

    public override IEnumerator ShowSuperArmorFeedback(float duration)
    {
        if(data.hasSuperArmor && myCharacterColor != null)
        {
            SpriteRenderer[] sRenderers = spritesParent.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer sr in sRenderers)
                sr.color = Color.red;
            yield return new WaitForSeconds(duration);
            foreach(SpriteRenderer sr in sRenderers)
                sr.color = myCharacterColor;
        }
        else
            yield return base.ShowSuperArmorFeedback(duration);
    }
}
