using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tether : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Necessary Attachments")]
    [SerializeField] private playerControl player = null;
    // public GameObject tether;
    [HideInInspector] public TetherPoint activeTetherPoint = null;

    [Header("Level Designer Variables")]
    [SerializeField] private ForceMode forceMode = ForceMode.Acceleration;
    [Min(0)] [SerializeField] private float tensionFactor = 1;

    void OnEnable()
    {
        player.input.Gameplay.Tether.Enable();
    }

    void OnDisable()
    {
        player.input.Gameplay.Tether.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }
    
    public void TetherSwing(float tetherLength, Vector3 tetherDirection, float theta)
    {
        float playerWeight = rb.mass * Physics.gravity.magnitude;
        if(player.inGuntime)
            playerWeight *= 6f;
        Vector3 tension = Mathf.Cos(theta) * playerWeight * tetherLength * tensionFactor * tetherDirection.normalized;
        rb.AddForce(tension, forceMode); // Tension
        Debug.DrawLine(rb.position, rb.position + tension, Color.red);

        Vector3 tempTether = tetherDirection;
        Vector3 pendulumForce = Vector3.down;
        Vector3.OrthoNormalize(ref tempTether, ref pendulumForce);
        pendulumForce *= (Mathf.Cos(theta) * playerWeight);
        rb.AddForce(pendulumForce, forceMode); // Tangential Force
        Debug.DrawLine(rb.position, rb.position + pendulumForce, Color.blue);

        Debug.DrawLine(rb.position, rb.position + rb.velocity);
    }

    public void ActivateTether(InputAction.CallbackContext context)
    {
        if(activeTetherPoint != null)
        {
            if(rb.position.y < activeTetherPoint.transform.position.y)
            {
                IState tetherState = new PlayerTether(player);
                player.GoToState(tetherState);
            }
        }
        // Debug.Log(myState);
    }

    public void Untether(InputAction.CallbackContext context)
    {
        if(activeTetherPoint != null)
        {
            IState movingState = new PlayerMove(player, true);
            player.GoToState(movingState);
        }
    }
}
