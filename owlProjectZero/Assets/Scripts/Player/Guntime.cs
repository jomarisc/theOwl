using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Guntime : MonoBehaviour
{
    [SerializeField] private playerControl player;
    private const float MAX_GUNTIME_DURATION = 5f;
    private float guntimeDuration;
    [SerializeField] private float guntimeUsageRate = 0f;
    [SerializeField] private float guntimeRecoveryRate = 0f;
    [SerializeField] private Image guntimeMeter = null;
    public bool inGuntime { get; private set; } = false;
    public event InGuntimeChanged OnInGuntimeChanged;
    public delegate bool InGuntimeChanged();

    void Awake()
    {
        guntimeDuration = MAX_GUNTIME_DURATION;
    }

    void OnEnable()
    {
        Debug.Log("Guntime OnEnable()");
        player.input.Gameplay.Guntime.started += ToggleGuntime;
    }

    void OnDisable()
    {
        player.input.Gameplay.Guntime.started -= ToggleGuntime;
    }

    // Update is called once per frame
    void Update()
    {
        if(inGuntime)
        {
            // Use up guntime resource
            if(guntimeDuration > 0f)
            {
                guntimeDuration -= guntimeUsageRate * Time.deltaTime;
                guntimeMeter.fillAmount = guntimeDuration / MAX_GUNTIME_DURATION;
            }
            // If ran out of guntime resource, remove character from guntime
            else
                TurnOffGuntime();
        }
        else
        {
            // Recover any missing guntimeDuration
            if(guntimeDuration < MAX_GUNTIME_DURATION)
            {
                guntimeDuration += guntimeRecoveryRate * Time.deltaTime; // deltaTime is so that the recovery rate is hopefully framerate independent
                guntimeMeter.fillAmount = guntimeDuration / MAX_GUNTIME_DURATION;
            }
            // Cap guntimeDuration @ max value
            if(guntimeDuration > MAX_GUNTIME_DURATION)
                guntimeDuration = MAX_GUNTIME_DURATION;
        }
    }
    public void TurnOffGuntime()
    {
        player.GetComponent<Rigidbody>().useGravity = true;
        player.animator.speed /= 2;

        // Magic Numbers Ahead...
        if(player.data.maxSpeed == player.data.groundSpeed)
        {
            player.data.groundSpeed /= 2f;
            player.data.maxSpeed = player.data.groundSpeed;
            player.data.airSpeed /= 2f;
        }
        else if(player.data.maxSpeed == player.data.airSpeed)
        {
            player.data.airSpeed /= 2f;
            player.data.maxSpeed = player.data.airSpeed;
            player.data.groundSpeed /= 2f;
        }
        player.data.jumpDistance /= 2f;
        
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.016f * Time.timeScale;

        inGuntime = false;
        OnInGuntimeChanged?.Invoke();
    }

    public void ToggleGuntime(InputAction.CallbackContext context)
    {
        inGuntime = !inGuntime;
        OnInGuntimeChanged?.Invoke();

        if(inGuntime)
        {

            // Magic Numbers Ahead...
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.016f * Time.timeScale;

            player.GetComponent<Rigidbody>().useGravity = false;

            player.animator.speed *= 2;

            if(player.data.maxSpeed == player.data.groundSpeed)
            {
                player.data.groundSpeed *= 2f;
                player.data.maxSpeed = player.data.groundSpeed;
                player.data.airSpeed *= 2f;
            }
            else if(player.data.maxSpeed == player.data.airSpeed)
            {
                player.data.airSpeed *= 2f;
                player.data.maxSpeed = player.data.airSpeed;
                player.data.groundSpeed *= 2f;
            }
            player.data.jumpDistance *= 2f;
        }
        else
        {
            TurnOffGuntime();
        }
    }
}
