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
                    ""name"": """",
                    ""id"": ""d065f782-6a1f-4d39-a6b6-2a6995b0aaf4"",
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
                    ""path"": ""<Gamepad>/leftTrigger"",
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
                    ""path"": ""<Gamepad>/leftTrigger"",
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
        },
        {
            ""name"": ""Dodging"",
            ""id"": ""9c13feb3-f5ad-4560-953a-908f28e2a779"",
            ""actions"": [
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""d6707958-558a-440a-a407-81fa28b468e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""dfc185ba-42da-4937-93c1-3ac0c7ade521"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3c6efdfa-cb83-4593-8b04-7616f1b30801"",
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
                    ""id"": ""808468b8-2bf0-45ff-af6f-80d57455b081"",
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
                    ""id"": ""e5af07ed-30ce-4d0d-bf9e-e30f938d5e47"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""2bfc4bd9-56a5-4b56-9ad3-70ec41b64003"",
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
                    ""id"": ""05556c75-0ca5-4eeb-b880-5d85fe4b06b0"",
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
                    ""id"": ""b99b10f7-4bdd-4dc0-b95a-3038203d7bfa"",
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
                    ""id"": ""e4cb827d-707f-40a1-9399-a332c2686213"",
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
                    ""id"": ""7a85c372-c0e6-4eea-b705-604f3f5ce87f"",
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
                    ""id"": ""2a7e913c-6426-4a00-96bf-15252a7bd7eb"",
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
                    ""id"": ""0864957a-08dc-4b52-b4a0-85dbb7d68666"",
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
                    ""id"": ""0c16b9c3-2188-429a-b08d-5dc5bc4d7d1d"",
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
                    ""id"": ""10726353-6a8d-4a44-943e-be9fb51ccb5e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Jumping"",
            ""id"": ""ea352497-66ba-4c8d-a9aa-e461b146a168"",
            ""actions"": [
                {
                    ""name"": ""Tether"",
                    ""type"": ""Button"",
                    ""id"": ""ff3cfc14-db2a-40a5-9850-ea63f01e445d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Double Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f027dcf9-864e-4bae-81b0-63e3bc88486b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""02a7f34e-8bb9-4fcc-9ad5-c775922a7730"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""a3ee947f-f3ae-4c5a-b98d-301f30a35877"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot Projectile"",
                    ""type"": ""Button"",
                    ""id"": ""f9d6b9ae-6e4c-41c9-b257-068921d0d15f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""1a2c671c-c01e-4830-b620-02e1d7625f7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone(min=0.8)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fast Fall"",
                    ""type"": ""Button"",
                    ""id"": ""c7b40af8-b5ee-474f-9d1e-50ac0d44a818"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone(min=0.8)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fly"",
                    ""type"": ""Value"",
                    ""id"": ""61655e5e-641d-43dd-8c8a-eb342e060cf9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""138fdf78-e2ab-4224-88fc-b58a34bff4cb"",
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
                    ""id"": ""deba008e-bc42-4b1f-bfb0-77476b0d2064"",
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
                    ""id"": ""3f2e3aa9-7a23-4c4f-af96-4c65959244c3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Double Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b77fd624-4196-4f81-b107-b675ff72276d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Double Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""396fa2b6-8b06-40f8-b5b3-9fa2ca1e12ee"",
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
                    ""id"": ""8e2a78e2-2879-44ac-97b1-973c637f3900"",
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
                    ""id"": ""8d88ecbd-4679-414f-a226-173ae9494119"",
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
                    ""id"": ""54c0793f-5780-4ebc-9dee-797c20dd4ae0"",
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
                    ""id"": ""ea094eae-a96b-4a60-9475-19c21867e2cc"",
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
                    ""id"": ""f9edf01f-b929-4a5e-8dac-7fad3bfd6d6e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot Projectile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e8bef77-8aea-4c60-846c-37f3f96e03de"",
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
                    ""id"": ""c21bed27-403f-40c3-a7fa-2350cf748c2f"",
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
                    ""id"": ""2f256f85-90f6-42f1-b21b-d1bbd445290d"",
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
                    ""id"": ""685d29ac-a689-4e64-afa0-150149a9ff4f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fast Fall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4043e78c-b742-4368-90f9-41a77d52bb3d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fast Fall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca76beab-9256-4322-93c9-2953dd7f8343"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fast Fall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""01cb2a64-216b-49f2-921f-58f4587a06fb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d6e6c871-799f-45fe-9b30-c23745ba8626"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c863e659-a81e-42bd-9dab-278625133591"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6f3affee-a0fe-49fa-822a-84403d72ebb6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e672dbf4-0837-400c-b683-d24444715816"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f96b3bbe-c5b0-4e29-9ed5-b04619fd28e3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""7c0a9c92-5624-4f28-a2dd-36762c374ae7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""08dc16fa-7f2d-453b-b698-0a9aae85fc7d"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f8cc43fa-7457-4154-8960-8a15b27a0144"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Melee"",
            ""id"": ""1937122c-d389-4f84-b5b7-346cbc777f47"",
            ""actions"": [
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""fd5db2b1-7dfa-4603-b124-12c3e7ca6c7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65a54232-abee-4156-b473-dcca8bcf5faa"",
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
                    ""id"": ""5cb40ff2-b31b-4a4d-be64-6e2602c549a3"",
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
                    ""id"": ""5d247578-3684-40d3-be37-750456a0386a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shooting"",
            ""id"": ""58e8c5c7-0f59-4e21-b3f5-c799702c3176"",
            ""actions"": [
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""7ffec2db-1cd3-455b-b4a7-125ce8ac52af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6501cf28-72cd-49e8-a994-6c8215e34705"",
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
                    ""id"": ""45d060a0-4dce-4bfe-b06a-39391f097afb"",
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
                    ""id"": ""63eca9df-28e6-4c61-a558-cf61f5b8bd20"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gliding"",
            ""id"": ""493afd2a-132c-4226-bdd4-874a5bb19b1e"",
            ""actions"": [
                {
                    ""name"": ""Tether"",
                    ""type"": ""Button"",
                    ""id"": ""17311fc8-3838-4906-b73e-4f4e15717983"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""44cdb778-879b-47c3-af9c-a8a8fbb8d14d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""45bc0069-26ee-46f5-b96e-8c104b754572"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""2ef3be00-fc78-4786-a11a-fa62f8d0c41b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootProjectile"",
                    ""type"": ""Button"",
                    ""id"": ""dc95945a-991d-4b24-bbe2-dd974f67a9d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""6ef3b096-9393-433a-a6a9-662018d3d48b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone(min=0.8)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fly"",
                    ""type"": ""Value"",
                    ""id"": ""73f1c9c5-42d3-4647-8178-7624caeae43e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a1ab78f2-86c3-499a-8a9e-b8b92c23eff4"",
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
                    ""id"": ""ce17de2f-0209-4f52-a057-1413554cb6dc"",
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
                    ""id"": ""08c6a7d3-ef04-450f-b15b-6b650624f485"",
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
                    ""id"": ""207b003d-afba-4afc-b607-99cc4fe4850c"",
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
                    ""id"": ""8b184f43-7055-4c76-b5d2-bd3d3bf3c560"",
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
                    ""id"": ""c8ca26d8-470f-463d-98b0-a09158d2f652"",
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
                    ""id"": ""c72e4e1b-7801-480c-aa69-665ed9a93e64"",
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
                    ""id"": ""adab8c0c-a8aa-4959-9634-f3f4f414f9f0"",
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
                    ""id"": ""97428e13-4ac8-45a9-bf0a-0ae2fbbe7c6b"",
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
                    ""id"": ""b7f98591-683c-47f6-b4c8-84b1322afa4d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootProjectile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""50d4df10-7ef4-4260-9eb4-6f3fbccfb608"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""50695aaa-bd69-4138-9d71-3d589c943933"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b98afbed-f17f-4b89-9ddb-689904bce2f6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""1dff278e-1663-4ae1-941b-60e483b61423"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0758b0ec-e516-45e5-8957-e8b212a2530a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""815f53ff-2136-4b30-bc56-17297290bc18"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""893153a6-116b-4228-aaef-43c11597396b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3b4854ca-5422-4f16-a3df-668f926652bd"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""63ea287f-22ce-461a-a666-3b6717dfab83"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a875b8fc-c881-4939-91d0-83b77963d161"",
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
                    ""id"": ""f048bf51-7344-48cc-ae36-e53ccb1c8eaa"",
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
                    ""id"": ""a5906c8d-9f46-4ef0-8761-d62cd098658c"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Glide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        // Dodging
        m_Dodging = asset.FindActionMap("Dodging", throwIfNotFound: true);
        m_Dodging_Glide = m_Dodging.FindAction("Glide", throwIfNotFound: true);
        m_Dodging_Walk = m_Dodging.FindAction("Walk", throwIfNotFound: true);
        // Jumping
        m_Jumping = asset.FindActionMap("Jumping", throwIfNotFound: true);
        m_Jumping_Tether = m_Jumping.FindAction("Tether", throwIfNotFound: true);
        m_Jumping_DoubleJump = m_Jumping.FindAction("Double Jump", throwIfNotFound: true);
        m_Jumping_Dodge = m_Jumping.FindAction("Dodge", throwIfNotFound: true);
        m_Jumping_Melee = m_Jumping.FindAction("Melee", throwIfNotFound: true);
        m_Jumping_ShootProjectile = m_Jumping.FindAction("Shoot Projectile", throwIfNotFound: true);
        m_Jumping_Glide = m_Jumping.FindAction("Glide", throwIfNotFound: true);
        m_Jumping_FastFall = m_Jumping.FindAction("Fast Fall", throwIfNotFound: true);
        m_Jumping_Fly = m_Jumping.FindAction("Fly", throwIfNotFound: true);
        // Melee
        m_Melee = asset.FindActionMap("Melee", throwIfNotFound: true);
        m_Melee_Glide = m_Melee.FindAction("Glide", throwIfNotFound: true);
        // Shooting
        m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
        m_Shooting_Glide = m_Shooting.FindAction("Glide", throwIfNotFound: true);
        // Gliding
        m_Gliding = asset.FindActionMap("Gliding", throwIfNotFound: true);
        m_Gliding_Tether = m_Gliding.FindAction("Tether", throwIfNotFound: true);
        m_Gliding_Dodge = m_Gliding.FindAction("Dodge", throwIfNotFound: true);
        m_Gliding_Jump = m_Gliding.FindAction("Jump", throwIfNotFound: true);
        m_Gliding_Melee = m_Gliding.FindAction("Melee", throwIfNotFound: true);
        m_Gliding_ShootProjectile = m_Gliding.FindAction("ShootProjectile", throwIfNotFound: true);
        m_Gliding_Glide = m_Gliding.FindAction("Glide", throwIfNotFound: true);
        m_Gliding_Fly = m_Gliding.FindAction("Fly", throwIfNotFound: true);
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

    // Dodging
    private readonly InputActionMap m_Dodging;
    private IDodgingActions m_DodgingActionsCallbackInterface;
    private readonly InputAction m_Dodging_Glide;
    private readonly InputAction m_Dodging_Walk;
    public struct DodgingActions
    {
        private @PlayerInputs m_Wrapper;
        public DodgingActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Glide => m_Wrapper.m_Dodging_Glide;
        public InputAction @Walk => m_Wrapper.m_Dodging_Walk;
        public InputActionMap Get() { return m_Wrapper.m_Dodging; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DodgingActions set) { return set.Get(); }
        public void SetCallbacks(IDodgingActions instance)
        {
            if (m_Wrapper.m_DodgingActionsCallbackInterface != null)
            {
                @Glide.started -= m_Wrapper.m_DodgingActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_DodgingActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_DodgingActionsCallbackInterface.OnGlide;
                @Walk.started -= m_Wrapper.m_DodgingActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_DodgingActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_DodgingActionsCallbackInterface.OnWalk;
            }
            m_Wrapper.m_DodgingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Glide.started += instance.OnGlide;
                @Glide.performed += instance.OnGlide;
                @Glide.canceled += instance.OnGlide;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
            }
        }
    }
    public DodgingActions @Dodging => new DodgingActions(this);

    // Jumping
    private readonly InputActionMap m_Jumping;
    private IJumpingActions m_JumpingActionsCallbackInterface;
    private readonly InputAction m_Jumping_Tether;
    private readonly InputAction m_Jumping_DoubleJump;
    private readonly InputAction m_Jumping_Dodge;
    private readonly InputAction m_Jumping_Melee;
    private readonly InputAction m_Jumping_ShootProjectile;
    private readonly InputAction m_Jumping_Glide;
    private readonly InputAction m_Jumping_FastFall;
    private readonly InputAction m_Jumping_Fly;
    public struct JumpingActions
    {
        private @PlayerInputs m_Wrapper;
        public JumpingActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tether => m_Wrapper.m_Jumping_Tether;
        public InputAction @DoubleJump => m_Wrapper.m_Jumping_DoubleJump;
        public InputAction @Dodge => m_Wrapper.m_Jumping_Dodge;
        public InputAction @Melee => m_Wrapper.m_Jumping_Melee;
        public InputAction @ShootProjectile => m_Wrapper.m_Jumping_ShootProjectile;
        public InputAction @Glide => m_Wrapper.m_Jumping_Glide;
        public InputAction @FastFall => m_Wrapper.m_Jumping_FastFall;
        public InputAction @Fly => m_Wrapper.m_Jumping_Fly;
        public InputActionMap Get() { return m_Wrapper.m_Jumping; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JumpingActions set) { return set.Get(); }
        public void SetCallbacks(IJumpingActions instance)
        {
            if (m_Wrapper.m_JumpingActionsCallbackInterface != null)
            {
                @Tether.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnTether;
                @Tether.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnTether;
                @Tether.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnTether;
                @DoubleJump.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnDoubleJump;
                @DoubleJump.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnDoubleJump;
                @DoubleJump.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnDoubleJump;
                @Dodge.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnDodge;
                @Melee.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnMelee;
                @ShootProjectile.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnShootProjectile;
                @Glide.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnGlide;
                @FastFall.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnFastFall;
                @FastFall.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnFastFall;
                @FastFall.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnFastFall;
                @Fly.started -= m_Wrapper.m_JumpingActionsCallbackInterface.OnFly;
                @Fly.performed -= m_Wrapper.m_JumpingActionsCallbackInterface.OnFly;
                @Fly.canceled -= m_Wrapper.m_JumpingActionsCallbackInterface.OnFly;
            }
            m_Wrapper.m_JumpingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tether.started += instance.OnTether;
                @Tether.performed += instance.OnTether;
                @Tether.canceled += instance.OnTether;
                @DoubleJump.started += instance.OnDoubleJump;
                @DoubleJump.performed += instance.OnDoubleJump;
                @DoubleJump.canceled += instance.OnDoubleJump;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @ShootProjectile.started += instance.OnShootProjectile;
                @ShootProjectile.performed += instance.OnShootProjectile;
                @ShootProjectile.canceled += instance.OnShootProjectile;
                @Glide.started += instance.OnGlide;
                @Glide.performed += instance.OnGlide;
                @Glide.canceled += instance.OnGlide;
                @FastFall.started += instance.OnFastFall;
                @FastFall.performed += instance.OnFastFall;
                @FastFall.canceled += instance.OnFastFall;
                @Fly.started += instance.OnFly;
                @Fly.performed += instance.OnFly;
                @Fly.canceled += instance.OnFly;
            }
        }
    }
    public JumpingActions @Jumping => new JumpingActions(this);

    // Melee
    private readonly InputActionMap m_Melee;
    private IMeleeActions m_MeleeActionsCallbackInterface;
    private readonly InputAction m_Melee_Glide;
    public struct MeleeActions
    {
        private @PlayerInputs m_Wrapper;
        public MeleeActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Glide => m_Wrapper.m_Melee_Glide;
        public InputActionMap Get() { return m_Wrapper.m_Melee; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MeleeActions set) { return set.Get(); }
        public void SetCallbacks(IMeleeActions instance)
        {
            if (m_Wrapper.m_MeleeActionsCallbackInterface != null)
            {
                @Glide.started -= m_Wrapper.m_MeleeActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_MeleeActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_MeleeActionsCallbackInterface.OnGlide;
            }
            m_Wrapper.m_MeleeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Glide.started += instance.OnGlide;
                @Glide.performed += instance.OnGlide;
                @Glide.canceled += instance.OnGlide;
            }
        }
    }
    public MeleeActions @Melee => new MeleeActions(this);

    // Shooting
    private readonly InputActionMap m_Shooting;
    private IShootingActions m_ShootingActionsCallbackInterface;
    private readonly InputAction m_Shooting_Glide;
    public struct ShootingActions
    {
        private @PlayerInputs m_Wrapper;
        public ShootingActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Glide => m_Wrapper.m_Shooting_Glide;
        public InputActionMap Get() { return m_Wrapper.m_Shooting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
        public void SetCallbacks(IShootingActions instance)
        {
            if (m_Wrapper.m_ShootingActionsCallbackInterface != null)
            {
                @Glide.started -= m_Wrapper.m_ShootingActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_ShootingActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_ShootingActionsCallbackInterface.OnGlide;
            }
            m_Wrapper.m_ShootingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Glide.started += instance.OnGlide;
                @Glide.performed += instance.OnGlide;
                @Glide.canceled += instance.OnGlide;
            }
        }
    }
    public ShootingActions @Shooting => new ShootingActions(this);

    // Gliding
    private readonly InputActionMap m_Gliding;
    private IGlidingActions m_GlidingActionsCallbackInterface;
    private readonly InputAction m_Gliding_Tether;
    private readonly InputAction m_Gliding_Dodge;
    private readonly InputAction m_Gliding_Jump;
    private readonly InputAction m_Gliding_Melee;
    private readonly InputAction m_Gliding_ShootProjectile;
    private readonly InputAction m_Gliding_Glide;
    private readonly InputAction m_Gliding_Fly;
    public struct GlidingActions
    {
        private @PlayerInputs m_Wrapper;
        public GlidingActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tether => m_Wrapper.m_Gliding_Tether;
        public InputAction @Dodge => m_Wrapper.m_Gliding_Dodge;
        public InputAction @Jump => m_Wrapper.m_Gliding_Jump;
        public InputAction @Melee => m_Wrapper.m_Gliding_Melee;
        public InputAction @ShootProjectile => m_Wrapper.m_Gliding_ShootProjectile;
        public InputAction @Glide => m_Wrapper.m_Gliding_Glide;
        public InputAction @Fly => m_Wrapper.m_Gliding_Fly;
        public InputActionMap Get() { return m_Wrapper.m_Gliding; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlidingActions set) { return set.Get(); }
        public void SetCallbacks(IGlidingActions instance)
        {
            if (m_Wrapper.m_GlidingActionsCallbackInterface != null)
            {
                @Tether.started -= m_Wrapper.m_GlidingActionsCallbackInterface.OnTether;
                @Tether.performed -= m_Wrapper.m_GlidingActionsCallbackInterface.OnTether;
                @Tether.canceled -= m_Wrapper.m_GlidingActionsCallbackInterface.OnTether;
                @Dodge.started -= m_Wrapper.m_GlidingActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_GlidingActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_GlidingActionsCallbackInterface.OnDodge;
                @Jump.started -= m_Wrapper.m_GlidingActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GlidingActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GlidingActionsCallbackInterface.OnJump;
                @Melee.started -= m_Wrapper.m_GlidingActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_GlidingActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_GlidingActionsCallbackInterface.OnMelee;
                @ShootProjectile.started -= m_Wrapper.m_GlidingActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.performed -= m_Wrapper.m_GlidingActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.canceled -= m_Wrapper.m_GlidingActionsCallbackInterface.OnShootProjectile;
                @Glide.started -= m_Wrapper.m_GlidingActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_GlidingActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_GlidingActionsCallbackInterface.OnGlide;
                @Fly.started -= m_Wrapper.m_GlidingActionsCallbackInterface.OnFly;
                @Fly.performed -= m_Wrapper.m_GlidingActionsCallbackInterface.OnFly;
                @Fly.canceled -= m_Wrapper.m_GlidingActionsCallbackInterface.OnFly;
            }
            m_Wrapper.m_GlidingActionsCallbackInterface = instance;
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
                @Fly.started += instance.OnFly;
                @Fly.performed += instance.OnFly;
                @Fly.canceled += instance.OnFly;
            }
        }
    }
    public GlidingActions @Gliding => new GlidingActions(this);
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
    public interface IDodgingActions
    {
        void OnGlide(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
    }
    public interface IJumpingActions
    {
        void OnTether(InputAction.CallbackContext context);
        void OnDoubleJump(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnShootProjectile(InputAction.CallbackContext context);
        void OnGlide(InputAction.CallbackContext context);
        void OnFastFall(InputAction.CallbackContext context);
        void OnFly(InputAction.CallbackContext context);
    }
    public interface IMeleeActions
    {
        void OnGlide(InputAction.CallbackContext context);
    }
    public interface IShootingActions
    {
        void OnGlide(InputAction.CallbackContext context);
    }
    public interface IGlidingActions
    {
        void OnTether(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnShootProjectile(InputAction.CallbackContext context);
        void OnGlide(InputAction.CallbackContext context);
        void OnFly(InputAction.CallbackContext context);
    }
}
