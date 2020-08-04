// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""4cc7c28f-0a5c-4b74-9480-82d641c46d92"",
            ""actions"": [
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Value"",
                    ""id"": ""b25b7f2d-f4ce-4fd6-88ca-64f654069701"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenSkillWheel"",
                    ""type"": ""Value"",
                    ""id"": ""c157163c-6a2f-4ad3-8dcf-eaa9b419ccd8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""850d1e41-d5c2-4a71-9b91-e4749bce1d15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""9fa4e796-4ef2-461e-892d-5cb9b1284a90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Guntime"",
                    ""type"": ""Button"",
                    ""id"": ""961a01f1-6314-4894-a945-1bd8ce1cac4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseActiveSkill"",
                    ""type"": ""Button"",
                    ""id"": ""c52057ba-9e54-4c9b-90b9-c38e133061c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenSkillWheel2"",
                    ""type"": ""Button"",
                    ""id"": ""1698eaa6-c75c-48f4-8e7b-66524495cb41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""413adf38-8989-4f5f-a687-4dadd983316d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootProjectile"",
                    ""type"": ""Button"",
                    ""id"": ""5cb0596c-d53d-44f1-81ac-b4a7257f60ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tether"",
                    ""type"": ""Button"",
                    ""id"": ""e55e1274-09a1-4e16-bdcf-8e59d98c82d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""97bfaa79-a11e-4d51-a29c-eea52178b0ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8d49d2ad-d454-4d37-bdcf-593f7c3f1f37"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tether"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9e86e1a-d778-4e9a-b7b8-6bea16f5de9b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tether"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41fb7145-2361-4ccb-9a98-db11f3400e41"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1549d47d-b67b-4553-9b90-a1ceb7196082"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8c75d3e-847f-44af-b228-5d28596cb0b4"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""893154de-9875-44a1-ae41-628f6c76b3d9"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9707cfb-0d82-4351-92e8-29d39f8b8ad7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""decdd3d2-4f7d-40a6-9860-118aa4c3845a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad55b5fa-8cfe-44a5-aaf8-4e6bc4581297"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc615fe2-593d-491d-b654-cd154bf4c8ab"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04438b88-1aa5-40e1-8ef9-bf9a80e208fd"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guntime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8153b4a-f1aa-4621-bf60-09b529510982"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseActiveSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""5cf09c0d-96b6-4420-b110-00341988da97"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e29f25fa-7c87-4bae-b1c9-ce227194c7cf"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""86cf78b7-c9de-410c-822a-7729e6981ff3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2355c9ea-30eb-4b2c-813a-d5fa87cdfaee"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d295d43a-719d-4517-9c89-fb9ba635b2d4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0bb1b159-46de-44b5-b521-c76ab7bae2f0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""a2ba6584-f927-4ecf-90dd-4c118023d86b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ada0cec5-1bc8-4ed8-8e6c-60bf2022644c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2fa39056-34c1-4549-a8b4-b6a9c38f6ce3"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""279b2c67-dd16-448e-9d5a-7bbd1fcbb69a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b6681836-6f3f-4212-b917-9c4437bc92d4"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""98f2b688-ec0d-42fa-a14c-653d51f2bd56"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9f4f635b-9aa9-4241-8652-8336131e3337"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4ae3e51-1e2d-49d2-a883-5f62866dd4e1"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5975ac95-28ed-4292-ac4a-4f45c1a980bd"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1d755e6-3b36-4d79-8583-edc3deb7e403"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2aada28-2a03-4b2c-9a23-b5d1a949d700"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootProjectile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61ce5cf8-4f86-4e85-8be8-4ba39f27e762"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootProjectile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveX = m_Gameplay.FindAction("MoveX", throwIfNotFound: true);
        m_Gameplay_OpenSkillWheel = m_Gameplay.FindAction("OpenSkillWheel", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Melee = m_Gameplay.FindAction("Melee", throwIfNotFound: true);
        m_Gameplay_Guntime = m_Gameplay.FindAction("Guntime", throwIfNotFound: true);
        m_Gameplay_UseActiveSkill = m_Gameplay.FindAction("UseActiveSkill", throwIfNotFound: true);
        m_Gameplay_OpenSkillWheel2 = m_Gameplay.FindAction("OpenSkillWheel2", throwIfNotFound: true);
        m_Gameplay_Dodge = m_Gameplay.FindAction("Dodge", throwIfNotFound: true);
        m_Gameplay_ShootProjectile = m_Gameplay.FindAction("ShootProjectile", throwIfNotFound: true);
        m_Gameplay_Tether = m_Gameplay.FindAction("Tether", throwIfNotFound: true);
        m_Gameplay_Glide = m_Gameplay.FindAction("Glide", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MoveX;
    private readonly InputAction m_Gameplay_OpenSkillWheel;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Melee;
    private readonly InputAction m_Gameplay_Guntime;
    private readonly InputAction m_Gameplay_UseActiveSkill;
    private readonly InputAction m_Gameplay_OpenSkillWheel2;
    private readonly InputAction m_Gameplay_Dodge;
    private readonly InputAction m_Gameplay_ShootProjectile;
    private readonly InputAction m_Gameplay_Tether;
    private readonly InputAction m_Gameplay_Glide;
    public struct GameplayActions
    {
        private @PlayerInputs m_Wrapper;
        public GameplayActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveX => m_Wrapper.m_Gameplay_MoveX;
        public InputAction @OpenSkillWheel => m_Wrapper.m_Gameplay_OpenSkillWheel;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Melee => m_Wrapper.m_Gameplay_Melee;
        public InputAction @Guntime => m_Wrapper.m_Gameplay_Guntime;
        public InputAction @UseActiveSkill => m_Wrapper.m_Gameplay_UseActiveSkill;
        public InputAction @OpenSkillWheel2 => m_Wrapper.m_Gameplay_OpenSkillWheel2;
        public InputAction @Dodge => m_Wrapper.m_Gameplay_Dodge;
        public InputAction @ShootProjectile => m_Wrapper.m_Gameplay_ShootProjectile;
        public InputAction @Tether => m_Wrapper.m_Gameplay_Tether;
        public InputAction @Glide => m_Wrapper.m_Gameplay_Glide;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveX.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveX;
                @MoveX.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveX;
                @MoveX.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveX;
                @OpenSkillWheel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenSkillWheel;
                @OpenSkillWheel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenSkillWheel;
                @OpenSkillWheel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenSkillWheel;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Melee.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMelee;
                @Guntime.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGuntime;
                @Guntime.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGuntime;
                @Guntime.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGuntime;
                @UseActiveSkill.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUseActiveSkill;
                @UseActiveSkill.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUseActiveSkill;
                @UseActiveSkill.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUseActiveSkill;
                @OpenSkillWheel2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenSkillWheel2;
                @OpenSkillWheel2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenSkillWheel2;
                @OpenSkillWheel2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenSkillWheel2;
                @Dodge.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                @ShootProjectile.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootProjectile;
                @Tether.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTether;
                @Tether.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTether;
                @Tether.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTether;
                @Glide.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGlide;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveX.started += instance.OnMoveX;
                @MoveX.performed += instance.OnMoveX;
                @MoveX.canceled += instance.OnMoveX;
                @OpenSkillWheel.started += instance.OnOpenSkillWheel;
                @OpenSkillWheel.performed += instance.OnOpenSkillWheel;
                @OpenSkillWheel.canceled += instance.OnOpenSkillWheel;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @Guntime.started += instance.OnGuntime;
                @Guntime.performed += instance.OnGuntime;
                @Guntime.canceled += instance.OnGuntime;
                @UseActiveSkill.started += instance.OnUseActiveSkill;
                @UseActiveSkill.performed += instance.OnUseActiveSkill;
                @UseActiveSkill.canceled += instance.OnUseActiveSkill;
                @OpenSkillWheel2.started += instance.OnOpenSkillWheel2;
                @OpenSkillWheel2.performed += instance.OnOpenSkillWheel2;
                @OpenSkillWheel2.canceled += instance.OnOpenSkillWheel2;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @ShootProjectile.started += instance.OnShootProjectile;
                @ShootProjectile.performed += instance.OnShootProjectile;
                @ShootProjectile.canceled += instance.OnShootProjectile;
                @Tether.started += instance.OnTether;
                @Tether.performed += instance.OnTether;
                @Tether.canceled += instance.OnTether;
                @Glide.started += instance.OnGlide;
                @Glide.performed += instance.OnGlide;
                @Glide.canceled += instance.OnGlide;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMoveX(InputAction.CallbackContext context);
        void OnOpenSkillWheel(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnGuntime(InputAction.CallbackContext context);
        void OnUseActiveSkill(InputAction.CallbackContext context);
        void OnOpenSkillWheel2(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnShootProjectile(InputAction.CallbackContext context);
        void OnTether(InputAction.CallbackContext context);
        void OnGlide(InputAction.CallbackContext context);
    }
}
