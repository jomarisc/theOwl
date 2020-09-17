﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class EquippedSkills : MonoBehaviour
{
    [SerializeField] private playerControl player;
    public GameObject equippedSkillsUI;
    public Skill currentSkill;
    public Skill[] skills = new Skill[4];
    private bool usingFastSkillWheel = false;
    public static event SkillEquip OnSkillEquip;
    public delegate void SkillEquip();

    private void OnEnable()
    {
        player.input.Gameplay.UseActiveSkill.started += UseCurrentSkill;
    }

    private void OnDisable()
    {
        player.input.Gameplay.UseActiveSkill.started -= UseCurrentSkill;
    }

    private void Update()
    {
        if(!equippedSkillsUI.activeInHierarchy)
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

        if(equippedSkillsUI.activeInHierarchy)
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
    }

    // Use the current skill if unused and ready. Turn off current skill otherwise.
    public void UseCurrentSkill(InputAction.CallbackContext context)
    {
        if(currentSkill.isActive)
            currentSkill.DeactivateSkill();
        else
        {
            if(player.data.remainingStamana >= currentSkill.usageCost)
            {
                player.data.remainingStamana -= currentSkill.usageCost;
                currentSkill.UseSkill();
            }
            else
                Debug.Log("Not enough stamana!");
        }
    }

    public void OpenSkillWheel()
    {
        Time.timeScale = 0.5f;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(player.input.SkillWheel.Navigate);
        equippedSkillsUI.SetActive(true);
        StartCoroutine(ReadRightStickInput());
    }

    // A slower way of opening the skill wheel
    public void OpenSkillWheel2()
    {
        Time.timeScale = 0f;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(player.input.SkillWheel.Navigate);
        equippedSkillsUI.SetActive(true);
        Button slotOne = equippedSkillsUI.GetComponentInChildren<Button>();
        slotOne.Select();
        slotOne.OnSelect(null);
    }

    IEnumerator ReadRightStickInput()
    {
        yield return new WaitForEndOfFrame();
        Vector2 stickInput = player.input.Gameplay.OpenSkillWheel.ReadValue<Vector2>();
        while(stickInput.magnitude == 0f)
            yield return null;

        float stickAngle = Vector2.SignedAngle(stickInput, Vector2.up);
        Button[] skillSlots = equippedSkillsUI.GetComponentsInChildren<Button>();
        int index = 0;
        if(stickAngle < -45 && stickAngle > -135)
            index = 3;
        else if(stickAngle > 45 && stickAngle < 135)
            index = 1;
        else if(Mathf.Abs(stickAngle) > 90)
            index = 2;
        else
            index = 0;

        skillSlots[index].Select();
        skillSlots[index].OnSelect(null);
    }

    public void CloseSkillWheel()
    {
        usingFastSkillWheel = false;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).move = InputActionReference.Create(player.input.UI.Navigate);
        currentSkill = skills[EventSystem.current.currentSelectedGameObject.GetComponentInChildren<SkillWheelSlotUI>().slotNumber - 1];
        if(OnSkillEquip != null)
            OnSkillEquip();
        equippedSkillsUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
