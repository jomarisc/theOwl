using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct CharacterConstants
{
    public int MAX_JUMPS;
    public int MAX_DODGES;
    public float DEAD_DURATION;
}

[System.Serializable]
public struct CharacterData
{
    public int numJumps;
    public int numDodges;
    public float deadDuration;
    public float health;
    public float maxSpeed;
    public float groundSpeed;
    public float airSpeed;
    public float jumpDistance;
    public bool isFacingRight; // Determines whether the character is
                               //facing in the right-hand direction
                               // *So far, must be initialized in sub classes*
    public bool hasSuperArmor;

    //public Animator animator;
    public float remainingStamana;
}

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, ICharacter
{
    // private attributes

    // protected attributes
    protected Rigidbody rb;
    protected IState myState;

    // public attributes
    [field: Header("General")]
    [field: SerializeField] public CharacterConstants CONSTANTS { get; protected set; }
    public CharacterData data;
    public GameObject basicAttack;
    public Animator animator;
    public IState defaultState { get; protected set; }
    // public float DODGE_DURATION { get; protected set; }
    // public readonly int MAX_JUMPS;
    // public readonly int MAX_DODGES;
    // public readonly float DEAD_DURATION;

    // public Character(int maxJumps, int maxDodges, float deadDuration)
    // {
    //     MAX_JUMPS = maxJumps;
    //     MAX_DODGES = maxDodges;
    //     DEAD_DURATION = deadDuration;
    // }
    public Character()
    {
        
    }
    
    public virtual void Update()
    {
        if(data.health <= 0f)
        {
            //GetRekt();
        }

        IState currentState = myState.Update();
        if(currentState != null)
        {
            myState.Exit();
            myState = currentState;
            // Debug.Log(myState);
            myState.Enter();
        }
    }

    public virtual void FixedUpdate()
    {
        myState.FixedUpdate();
    }

    // Moves the player left/right based off of the value of its acceleration
    public virtual void MoveCharacter(float direction)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[0] = direction * data.maxSpeed;
        rb.velocity = newVelocity;
    }

    public void MoveCharacter(float xDirection, float yVelocity)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity[0] = xDirection * data.maxSpeed;
        newVelocity[1] = yVelocity;
        rb.velocity = newVelocity;
    }

    public void Jump()
    {
        if(data.numJumps > 0)
        {
            // Vector3 newVelocity = rb.velocity;
            // newVelocity[1] = data.jumpDistance;
            // rb.velocity = newVelocity;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0f, data.jumpDistance, 0f), ForceMode.VelocityChange);
            data.numJumps--;
        }
    }

    public void Attack()
    {
        Vector3 atkPos = basicAttack.transform.localPosition;
        int direction = (data.isFacingRight) ? 1 : -1;
        atkPos.x = direction * basicAttack.GetComponent<Attack>().initialLocalPosition.x;
        basicAttack.transform.localPosition = atkPos;
        basicAttack.GetComponent<Attack>().isFacingRight = data.isFacingRight;
    }

    public void GetRekt()
    {
        // New lines
        Debug.Log("Got rekt");
        //Destroy(this.gameObject);
        this.gameObject.active = false;
    }

    public void GoToDamagedState(float damageAmount, float knockback)
    {
        myState.Exit();
        myState = new CharacterDamaged(this, damageAmount, knockback);
        Debug.Log(myState);
        myState.Enter();
    }
    public void GoToState(IState state)
    {
        myState.Exit();
        myState = state;
        myState.Enter();
    }

    protected void ChangeSkill()
    {
        // Yet to be implemented
    }

    protected void OnCollisionStay(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null &&
           data.maxSpeed != data.groundSpeed)
        {
            data.maxSpeed = data.groundSpeed;
            animator.SetBool("grounded", true);
        }
            
    }
    protected void OnCollisionExit(Collision col)
    {
        if(col.gameObject.GetComponent<EnvironmentElement>() != null)
        {
            data.maxSpeed = data.airSpeed;
            animator.SetBool("grounded", false);
        }
            
    }
}
