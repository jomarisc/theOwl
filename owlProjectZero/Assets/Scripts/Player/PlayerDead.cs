using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : IState
{
    private readonly playerControl player;
    private Animator animator;
    private Rigidbody playerBody;
    private SpriteRenderer spriteRenderer;
    private string myAnimationState;
    private string defaultScene = "Alley";
    
    public PlayerDead(playerControl p)
    {
        player = p;
        animator = p.animator;
        playerBody = p.GetComponent<Rigidbody>();
        spriteRenderer = p.GetComponent<SpriteRenderer>();
    }

    public void Enter()
    {
        CheckpointsHandler.isDead = true;
        myAnimationState = "PlayerHurt";
        animator.Play(myAnimationState);
        player.deathSfx.Play();

        player.GetComponent<SpriteRenderer>().color = Color.red;
        player.data.deadDuration = player.CONSTANTS.DEAD_DURATION;
        player.dodgeAbility.dodgeDuration = player.data.deadDuration;
        player.dodgeAbility.PerformDodge();
        player.input.Gameplay.Disable();
    }

    public void Exit()
    {
        player.GetComponent<SpriteRenderer>().color = Color.white;
        player.input.Gameplay.Enable();
        player.dodgeAbility.LeaveDodge();
        Debug.Log("Left Dodge");
        // player.healthbar.ResetHealth();
        // player.healthbar.Redraw();
        // Old code
        //player.GetRekt();// Nothing so far
        //SceneManager.LoadScene("SampleScene");

        if(CheckpointsHandler.checkpointScene != null){
            SceneManager.LoadScene(CheckpointsHandler.checkpointScene);
        }
        else
        {
            SceneManager.LoadScene(defaultScene);
        }
    }

    public void FixedUpdate()
    {

    }

    public IState Update()
    {
        if(playerBody.velocity.x < 0)
            spriteRenderer.flipX = false;
        else if(playerBody.velocity.x > 0)
            spriteRenderer.flipX = true;

        if(myAnimationState.Equals("PlayerHurt") &&
           player.data.maxSpeed == player.data.groundSpeed &&
           playerBody.velocity.y == 0f)
        {
            myAnimationState = "PlayerDeath";
            animator.Play(myAnimationState);
        }

        if (player.data.deadDuration >= 0f)
        {
            player.data.deadDuration -= Time.deltaTime; // 3.0 - The completion time in seconds since the last frame
            return null;
        }
        // if(player.data.maxSpeed == player.data.airSpeed)
        //     return new PlayerMove(player, true);
        return new PlayerLimbo(player);
    }

        // Remember to handle collision between player and enemy
}
