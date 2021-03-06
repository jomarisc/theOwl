using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

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
        input.UI.PressAnyButton.performed += SelectButton;
    }

    private void OnDisable()
    {
        input.UI.PressAnyButton.performed -= SelectButton;
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
    }

    public void SelectButton(InputAction.CallbackContext context)
    {
        Debug.Log("Pressing any button");
        GetComponent<Button>().onClick.Invoke();
    }

    public void SetInputModuleLeftClick(InputActionReference action)
    {
        // ((InputSystemUIInputModule)EventSystem.current.currentInputModule).enabled = false;
        // ((InputSystemUIInputModule)EventSystem.current.currentInputModule).actionsAsset = regularUIInput;
        // ((InputSystemUIInputModule)EventSystem.current.currentInputModule).enabled = true;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).leftClick = null;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).leftClick = action; // leftClickAction;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).ActivateModule();
        // EventSystem.current.currentInputModule.enabled = true;
    }

    public void SetInputModuleSubmit(InputActionReference action)
    {
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).submit = null;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).submit = action; // submitAction;
        ((InputSystemUIInputModule)EventSystem.current.currentInputModule).ActivateModule();
        // EventSystem.current.currentInputModule.enabled = true;
    }
}
