using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;

public class SkillWheelUI : MonoBehaviour
{
    [SerializeField] private playerControl player = null;
    private bool usingFastSkillWheel = false;
    private Button[] slots;
    public static event SkillEquip OnSkillEquip;
    public delegate void SkillEquip();

    private void Start()
    {
        player = GameObject.Find("player").GetComponent<playerControl>();
        slots = GetComponentsInChildren<Button>(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if(SkillWheelIsPartiallyOpen()) // (slots[0].enabled) // (this.enabled)
        {
            if(usingFastSkillWheel)
            {
                if(player.input.Gameplay.OpenSkillWheel.ReadValue<Vector2>().magnitude < 0.125f)
                {
                    CloseSkillWheel();
                    Debug.Log(player.input.Gameplay.OpenSkillWheel.phase);
                    player.input.Gameplay.Melee.Enable();
                    player.input.Gameplay.Guntime.Enable();
                    player.input.Gameplay.ShootProjectile.Enable();
                }
            }
            // else
            // {
            //     if(player.input.Gameplay.OpenSkillWheel2.ReadValue<float>() == 0f)
            //     {
            //         CloseSkillWheel();
            //         Debug.Log(player.input.Gameplay.OpenSkillWheel2.phase);
            //         // player.input.Gameplay.Enable();
            //         player.input.Gameplay.MoveX.Enable();
            //         player.input.Gameplay.Jump.Enable();
            //         player.input.Gameplay.Melee.Enable();
            //         player.input.Gameplay.Guntime.Enable();
            //         player.input.Gameplay.Dodge.Enable();
            //         player.input.Gameplay.ShootProjectile.Enable();
            //         player.input.Gameplay.Tether.Enable();
            //         player.input.Gameplay.Glide.Enable();
            //     }
            // }
        }
        else // if(!slots[0].enabled) // (!this.enabled)
        {
            if(player.input.Gameplay.OpenSkillWheel.ReadValue<Vector2>().magnitude >= 0.125f)
            {
                usingFastSkillWheel = true;
                OpenSkillWheel();
                Debug.Log(player.input.Gameplay.OpenSkillWheel.phase);
                player.input.Gameplay.Melee.Disable();
                player.input.Gameplay.Guntime.Disable();
                player.input.Gameplay.ShootProjectile.Disable();
            }
            // else if(player.input.Gameplay.OpenSkillWheel2.ReadValue<float>() == 1f)
            // {
            //     usingFastSkillWheel = false;
            //     OpenSkillWheel2();
            //     Debug.Log(player.input.Gameplay.OpenSkillWheel2.phase);
            //     // player.input.Gameplay.Disable();
            //     player.input.Gameplay.MoveX.Disable();
            //     player.input.Gameplay.Jump.Disable();
            //     player.input.Gameplay.Melee.Disable();
            //     player.input.Gameplay.Guntime.Disable();
            //     player.input.Gameplay.Dodge.Disable();
            //     player.input.Gameplay.ShootProjectile.Disable();
            //     player.input.Gameplay.Tether.Disable();
            //     player.input.Gameplay.Glide.Disable();
            // }
        }
    }

    private bool SkillWheelIsPartiallyOpen()
    {
        // Check if any part of the skill wheel is enabled
        for(int i = 0; i < slots.Length; i++)
            if(slots[i].gameObject.activeInHierarchy)
                return true;
        return false;
    }

    private void ToggleSlots(bool onOrOff)
    {
        Debug.Log($"Enabling all slots? {onOrOff}");
        foreach(var slot in slots)
            slot.gameObject.SetActive(onOrOff);
    }

    public void OpenSkillWheel()
    {
        Time.timeScale = 0.5f;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(player.input.SkillWheel.Navigate);
        // this.enabled = true;
        ToggleSlots(true);
        StartCoroutine(ReadRightStickInput());
    }

    // A slower way of opening the skill wheel
    public void OpenSkillWheel2()
    {
        Time.timeScale = 0f;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(player.input.SkillWheel.Navigate);
        // this.enabled = true;
        ToggleSlots(true);
        // Button slotOne = this.GetComponentInChildren<Button>();
        // slotOne.Select();
        // slotOne.OnSelect(null);
        slots[0].Select();
        slots[0].OnSelect(null);
    }

    IEnumerator ReadRightStickInput()
    {
        yield return new WaitForEndOfFrame();
        Vector2 stickInput = player.input.Gameplay.OpenSkillWheel.ReadValue<Vector2>();
        while(stickInput.magnitude == 0f)
            yield return null;

        float stickAngle = Vector2.SignedAngle(stickInput, Vector2.up);
        // Button[] skillSlots = this.GetComponentsInChildren<Button>();
        int index = 0;
        if(stickAngle < -45 && stickAngle > -135)
            index = 3;
        else if(stickAngle > 45 && stickAngle < 135)
            index = 1;
        else if(Mathf.Abs(stickAngle) > 90)
            index = 2;
        else
            index = 0;

        // skillSlots[index].Select();
        // skillSlots[index].OnSelect(null);
        Debug.Log($"Index: {index}");
        Debug.Log($"Num slots: {slots.Length}");
        slots[index].Select();
        slots[index].OnSelect(null);
    }

    public void CloseSkillWheel()
    {
        usingFastSkillWheel = false;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(player.input.UI.Navigate);
        if(OnSkillEquip != null)
        {
            OnSkillEquip();
            Debug.Log("Equipped Skill");
        }
        // this.enabled = false;
        ToggleSlots(false);
        Time.timeScale = 1f;
    }
}
