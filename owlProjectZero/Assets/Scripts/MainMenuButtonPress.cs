using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MainMenuButtonPress : MonoBehaviour
{
    private PlayerInputs input;

    void Awake() => input = new PlayerInputs();
    void OnEnable() => StartCoroutine(ListenForInput());

    void OnDisable()
    {
        input.UI.Activate.performed -= ClickMyButton;
        input.Disable();
    }

    private IEnumerator ListenForInput()
    {
        yield return new WaitForSeconds(1.2f);
        yield return new WaitForFixedUpdate();
        input.Enable();
        input.UI.Activate.performed += ClickMyButton;
        yield return null;
    }
    
    public void ClickMyButton(InputAction.CallbackContext context)
    {
        Debug.Log("Clicked " + EventSystem.current.currentSelectedGameObject.name);
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
    }
}
