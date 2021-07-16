using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Controls;

public class Flash : MonoBehaviour
{
    public Image img;
    public GameObject theButton;
    public PlayerInputs input;

    private float timer;
    private Vector4 colortest;
    
    private void Awake()
    {
        input = new PlayerInputs();
    }
    private void OnEnable()
    {
        input.Enable();
        // input.UI.PressAnyButton.performed += SelectButton;
        
        InputSystem.onEvent += PressAnyButton;

    }

    private void OnDisable()
    {
        input.Disable();
    }
   
    private void Start()
    {
        //img = GetComponent<Image>();
        colortest = img.color;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            colortest = new Vector4(0f, 0f, 0f, 0f);
            img.color = colortest;
        }
        if (timer >= 1)
        {
            colortest = new Vector4(255f, 255f, 255f, 255f);
            img.color = colortest;
            timer = 0;
        }
    }

    public void SelectButton()
    {
        EventSystem.current.SetSelectedGameObject(theButton);
        // input.UI.PressAnyButton.performed -= SelectButton;
    }

    public void SelectButton(InputAction.CallbackContext context)
    {
        Debug.Log("Pressing any button");
        GetComponent<Button>().onClick.Invoke();
    }

    public void PressAnyButton(InputEventPtr eventPtr, InputDevice device)
    {
        if (!eventPtr.IsA<StateEvent>() && !eventPtr.IsA<DeltaStateEvent>())
            return;
    
        var controls = device.allControls;
        foreach (var control in controls)
        {
            if (!(control is ButtonControl button))
                continue;
            if (button.ReadValueFromEvent(eventPtr) > 0.5f) // 0.5f = InputSettings.defaultPressPoint
            {
                // Debug.Log($"Button {button} pressed");
                GetComponent<Button>().onClick.Invoke();
                InputSystem.onEvent -= PressAnyButton;
                break;
            }
        }
    }
}
