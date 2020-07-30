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
            ""name"": ""Idle"",
            ""id"": ""672fec67-897f-47d6-9b8c-bec2c81334a2"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""f4833d32-a9fe-4ac6-8397-acc185d6830f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""1130f239-08a0-4673-83bf-1f7702da6779"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""572411a9-1099-41b0-89ec-8ac9f6995379"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""3b103a8e-26bb-4412-833a-248b620609d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot Projectile"",
                    ""type"": ""Button"",
                    ""id"": ""34881b75-7d73-4cda-b711-b11192ee319a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""e8bff9ec-76ec-422b-950d-7ac9e586ef7e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""854d94d8-78fe-4e1d-9e8e-9524702ca8f5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""11820664-b01d-4c7c-a5b6-1443cf6c36fe"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""519bb0b6-792f-49e3-9d06-0dc59f9c9382"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c526cfd6-4ca6-4c42-9eeb-d91ab9971fc2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""57daf82d-0217-4120-b8b0-33a1db325cf2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""5897b79b-15b0-451a-8662-92dae615e362"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2b7d56f9-ce01-4f23-9883-1527d68204e9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0c31806d-5bf9-4c18-8a9e-b7aa29c0670f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""06baccb1-7439-4abf-8f14-b4298e8e6459"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""a098c6af-2eed-49cd-997e-c89b313586f5"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""379a94af-6978-47b1-896a-ccbb303229ca"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""71d8d188-eaa9-4524-bb4e-c9ef6be90c09"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""abf6ae61-0827-47bf-b6c3-3fec2431d25d"",
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
                    ""id"": ""137db586-e41c-4625-ad72-087702a48ae3"",
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
                    ""id"": ""8841bd39-9698-4c55-81c1-9c6160dc14f7"",
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
                    ""id"": ""91ecdbf5-ef38-495a-b9a6-c02f1143b153"",
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
                    ""id"": ""5e25f328-397a-40eb-86a6-d67d820b2b54"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot Projectile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc17d54b-4300-4fd9-9987-921de70a212d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot Projectile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Moving"",
            ""id"": ""4cc7c28f-0a5c-4b74-9480-82d641c46d92"",
            ""actions"": [
                {
                    ""name"": ""Tether"",
                    ""type"": ""Button"",
                    ""id"": ""e55e1274-09a1-4e16-bdcf-8e59d98c82d3"",
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
                    ""id"": ""b92607c6-1160-4bbf-b986-c98cef57597c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootProjectile"",
                    ""type"": ""Button"",
                    ""id"": ""90da7bbe-fbc0-4c3f-864a-901da3ffb34e"",
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
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""2d513d15-c7f2-4458-8996-d7489d6b4634"",
                    ""expectedControlType"": ""Axis"",
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
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tether"",
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
                    ""name"": ""Gamepad"",
                    ""id"": ""bc4e2b39-f2bd-43c5-a315-e94d6c4a4f8d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5a28fdab-30d0-432e-b895-f34387cedd6f"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""2d83cba2-ecb8-4221-987e-d495b225f881"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a00465d4-1d4d-4922-a581-69f61913ba73"",
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
                    ""id"": ""39a48477-6735-4b8c-ae93-fd297731f00e"",
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
                    ""id"": ""53270da1-77ce-4f54-922b-8073b439ab22"",
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
                    ""id"": ""f2a68614-6f8f-4bfb-8c95-1ef952411335"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootProjectile"",
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
                    ""name"": ""Arrow Keys"",
                    ""id"": ""d3fec23e-6f21-4051-ad4a-744546949cd2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5e23db0f-2946-45ad-8523-03a4c1b19bbb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5303e32f-1676-42a1-bfe4-8e5cb63a0a30"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""12c5ada5-8fbe-4efc-a072-4183720cb359"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0471aae9-e402-4972-8e40-7a386056c700"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fb94260b-17f3-45ea-bb4d-5a26dd048ecf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""93340dbf-0b2c-4018-be73-0ee9aec267c9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""22335dad-0387-484a-84b0-4b5a1de9afc8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d5aedb95-e2b1-4e9e-a2b5-414e56bcd0ce"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Idle
        m_Idle = asset.FindActionMap("Idle", throwIfNotFound: true);
        m_Idle_Walk = m_Idle.FindAction("Walk", throwIfNotFound: true);
        m_Idle_Dodge = m_Idle.FindAction("Dodge", throwIfNotFound: true);
        m_Idle_Jump = m_Idle.FindAction("Jump", throwIfNotFound: true);
        m_Idle_Melee = m_Idle.FindAction("Melee", throwIfNotFound: true);
        m_Idle_ShootProjectile = m_Idle.FindAction("Shoot Projectile", throwIfNotFound: true);
        // Moving
        m_Moving = asset.FindActionMap("Moving", throwIfNotFound: true);
        m_Moving_Tether = m_Moving.FindAction("Tether", throwIfNotFound: true);
        m_Moving_Dodge = m_Moving.FindAction("Dodge", throwIfNotFound: true);
        m_Moving_Jump = m_Moving.FindAction("Jump", throwIfNotFound: true);
        m_Moving_Melee = m_Moving.FindAction("Melee", throwIfNotFound: true);
        m_Moving_ShootProjectile = m_Moving.FindAction("ShootProjectile", throwIfNotFound: true);
        m_Moving_Glide = m_Moving.FindAction("Glide", throwIfNotFound: true);
        m_Moving_Walk = m_Moving.FindAction("Walk", throwIfNotFound: true);
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

    // Idle
    private readonly InputActionMap m_Idle;
    private IIdleActions m_IdleActionsCallbackInterface;
    private readonly InputAction m_Idle_Walk;
    private readonly InputAction m_Idle_Dodge;
    private readonly InputAction m_Idle_Jump;
    private readonly InputAction m_Idle_Melee;
    private readonly InputAction m_Idle_ShootProjectile;
    public struct IdleActions
    {
        private @PlayerInputs m_Wrapper;
        public IdleActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Idle_Walk;
        public InputAction @Dodge => m_Wrapper.m_Idle_Dodge;
        public InputAction @Jump => m_Wrapper.m_Idle_Jump;
        public InputAction @Melee => m_Wrapper.m_Idle_Melee;
        public InputAction @ShootProjectile => m_Wrapper.m_Idle_ShootProjectile;
        public InputActionMap Get() { return m_Wrapper.m_Idle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(IdleActions set) { return set.Get(); }
        public void SetCallbacks(IIdleActions instance)
        {
            if (m_Wrapper.m_IdleActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_IdleActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_IdleActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_IdleActionsCallbackInterface.OnWalk;
                @Dodge.started -= m_Wrapper.m_IdleActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_IdleActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_IdleActionsCallbackInterface.OnDodge;
                @Jump.started -= m_Wrapper.m_IdleActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_IdleActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_IdleActionsCallbackInterface.OnJump;
                @Melee.started -= m_Wrapper.m_IdleActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_IdleActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_IdleActionsCallbackInterface.OnMelee;
                @ShootProjectile.started -= m_Wrapper.m_IdleActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.performed -= m_Wrapper.m_IdleActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.canceled -= m_Wrapper.m_IdleActionsCallbackInterface.OnShootProjectile;
            }
            m_Wrapper.m_IdleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @ShootProjectile.started += instance.OnShootProjectile;
                @ShootProjectile.performed += instance.OnShootProjectile;
                @ShootProjectile.canceled += instance.OnShootProjectile;
            }
        }
    }
    public IdleActions @Idle => new IdleActions(this);

    // Moving
    private readonly InputActionMap m_Moving;
    private IMovingActions m_MovingActionsCallbackInterface;
    private readonly InputAction m_Moving_Tether;
    private readonly InputAction m_Moving_Dodge;
    private readonly InputAction m_Moving_Jump;
    private readonly InputAction m_Moving_Melee;
    private readonly InputAction m_Moving_ShootProjectile;
    private readonly InputAction m_Moving_Glide;
    private readonly InputAction m_Moving_Walk;
    public struct MovingActions
    {
        private @PlayerInputs m_Wrapper;
        public MovingActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tether => m_Wrapper.m_Moving_Tether;
        public InputAction @Dodge => m_Wrapper.m_Moving_Dodge;
        public InputAction @Jump => m_Wrapper.m_Moving_Jump;
        public InputAction @Melee => m_Wrapper.m_Moving_Melee;
        public InputAction @ShootProjectile => m_Wrapper.m_Moving_ShootProjectile;
        public InputAction @Glide => m_Wrapper.m_Moving_Glide;
        public InputAction @Walk => m_Wrapper.m_Moving_Walk;
        public InputActionMap Get() { return m_Wrapper.m_Moving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovingActions set) { return set.Get(); }
        public void SetCallbacks(IMovingActions instance)
        {
            if (m_Wrapper.m_MovingActionsCallbackInterface != null)
            {
                @Tether.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnTether;
                @Tether.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnTether;
                @Tether.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnTether;
                @Dodge.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnDodge;
                @Jump.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnJump;
                @Melee.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnMelee;
                @ShootProjectile.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnShootProjectile;
                @Glide.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnGlide;
                @Walk.started -= m_Wrapper.m_MovingActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_MovingActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_MovingActionsCallbackInterface.OnWalk;
            }
            m_Wrapper.m_MovingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tether.started += instance.OnTether;
                @Tether.performed += instance.OnTether;
                @Tether.canceled += instance.OnTether;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @ShootProjectile.started += instance.OnShootProjectile;
                @ShootProjectile.performed += instance.OnShootProjectile;
                @ShootProjectile.canceled += instance.OnShootProjectile;
                @Glide.started += instance.OnGlide;
                @Glide.performed += instance.OnGlide;
                @Glide.canceled += instance.OnGlide;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
            }
        }
    }
    public MovingActions @Moving => new MovingActions(this);
    public interface IIdleActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnShootProjectile(InputAction.CallbackContext context);
    }
    public interface IMovingActions
    {
        void OnTether(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnShootProjectile(InputAction.CallbackContext context);
        void OnGlide(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
    }
}
