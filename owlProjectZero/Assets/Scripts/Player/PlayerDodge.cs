using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDodge : IState
{
    private readonly playerControl player;
    private SpriteRenderer playerRenderer;
    private Color playerColor;
    private Rigidbody playerBody;
    private PlayerInputs input;

    private Animator animator;
    

    public PlayerDodge(playerControl p)
    {
        player = p;
        playerRenderer = p.gameObject.GetComponent<SpriteRenderer>();
        playerColor = playerRenderer.color;
        playerBody = p.gameObject.GetComponent<Rigidbody>();
        animator = p.gameObject.GetComponent<Animator>();
        input = p.input;
    }
    public void Enter()
    {
        // use ground dodge animation here:
        int animationLayer = (GlobalVars.playerHasUnlockedSuit) ? 1 : 0;
        animator.Play("PlayerDodge", animationLayer);

        playerColor.a = player.dodgeAbility.alpha;
        playerRenderer.color = playerColor;
        player.dodgeAbility.dodgeDuration = player.dodgeAbility.fullDuration; //  player.DODGE_DURATION;
        player.data.numDodges--;

        playerBody.useGravity = player.dodgeAbility.USING_GRAVITY;
        playerBody.velocity = Vector3.zero;
        float direction = (player.data.isFacingRight) ? 1f : -1f;
        if(player.inGuntime)
        {
            playerBody.drag = player.dodgeAbility.DRAG * player.guntimeAbility.GUNTIME_SLOWDOWN_FACTOR;
            playerBody.AddForce(new Vector3(direction * player.dodgeAbility.PUSH_FORCE * 2, 0f, 0f), ForceMode.VelocityChange);
        }
        else
        {
            playerBody.drag = player.dodgeAbility.DRAG;
            playerBody.AddForce(new Vector3(direction * player.dodgeAbility.PUSH_FORCE, 0f, 0f), ForceMode.VelocityChange);
        }

        player.dodgeAbility.PerformDodge();
        player.input.Gameplay.UseActiveSkill.Disable();
    }

    public void Exit()
    {
        playerColor.a = 1f;
        playerRenderer.color = playerColor;
        playerBody.useGravity = true;
        playerBody.drag = 1.0f;
        player.dodgeAbility.dodgeDuration = -1f;

        player.dodgeAbility.LeaveDodge();
        player.input.Gameplay.UseActiveSkill.Enable();
    }

    public void FixedUpdate()
    {
        // player.Dodge();
    }

    public IState Update()
    {
        // -1 <= dodgeDuration <= DODGE_DURATION
        // Decrement dodgeDuration until it reaches below 0
        if(player.dodgeAbility.dodgeDuration >= 0f)
        {
            player.dodgeAbility.dodgeDuration -= Time.unscaledDeltaTime;
            return null;
        }

        // Check for glide input
        if(input.Gameplay.Glide.triggered)
            return new PlayerGlide(player, PlayerGlide.glideType.Down);

        // If the player has jumped and is still airborne
        // Should be changed to a airborne walk state instead
        // to avoid burning another jump automatically
        if(player.data.maxSpeed == player.data.airSpeed)
        {
            return new PlayerMove(player, true);
        }
        return new PlayerIdle(player);
    }
}
