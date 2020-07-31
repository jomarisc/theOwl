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
                    ""name"": ""Dpad"",
                    ""id"": ""185f3752-1fa0-4ee6-bc4f-9bf9a9e35864"",
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
                    ""id"": ""ce0d970b-0fa7-4a05-a38a-67b4d591b0ab"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8efd95e2-4350-420e-a0ff-30c7492015b4"",
                    ""path"": ""<Gamepad>/dpad/right"",
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
                    ""id"": ""b25b7f2d-f4ce-4fd6-88ca-64f654069701"",
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
                    ""name"": ""Arrow Keys"",
                    ""id"": ""5cf09c0d-96b6-4420-b110-00341988da97"",
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
                    ""id"": ""e29f25fa-7c87-4bae-b1c9-ce227194c7cf"",
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
                    ""id"": ""86cf78b7-c9de-410c-822a-7729e6981ff3"",
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
                    ""id"": ""2355c9ea-30eb-4b2c-813a-d5fa87cdfaee"",
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
                    ""id"": ""d295d43a-719d-4517-9c89-fb9ba635b2d4"",
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
                    ""id"": ""0bb1b159-46de-44b5-b521-c76ab7bae2f0"",
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
                    ""id"": ""a2ba6584-f927-4ecf-90dd-4c118023d86b"",
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
                    ""id"": ""ada0cec5-1bc8-4ed8-8e6c-60bf2022644c"",
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
                    ""id"": ""2fa39056-34c1-4549-a8b4-b6a9c38f6ce3"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
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
                    ""action"": ""Walk"",
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
                    ""action"": ""Walk"",
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
                    ""id"": ""1a01135b-b1be-40d9-a92d-34a3bba642fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""c1418538-a35c-47c1-a185-c03ef41d3e7d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""1681448d-5253-4aea-9513-7888d5715f57"",
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
                    ""id"": ""f222bb8b-4331-40d8-b314-876ceabb7681"",
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
                    ""id"": ""218ca7c0-cece-41bb-9b5a-db69b4d40419"",
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
                    ""id"": ""4a833bb0-c7bb-48b3-901b-887d1953d128"",
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
                    ""id"": ""ba6398f1-477f-4c56-a6f7-a1d357477730"",
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
                    ""id"": ""c7412194-7b04-4404-92b5-4f050fb55878"",
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
                    ""id"": ""8bdb2673-58b2-4d5a-938e-5d9742f3f511"",
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
                    ""id"": ""75484f8f-526e-4cba-b279-e427f673b058"",
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
                    ""id"": ""400056a3-8501-474e-bd51-1b7ea8aead7f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""12614cfa-3b7e-4f80-8163-adc221a65822"",
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
                    ""id"": ""0157219d-1aaa-48d3-b7e9-6605291d2d25"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b9945d1e-1803-42f6-a61f-5b78f6014379"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dab2b633-223c-4816-9eeb-5871a1defc2a"",
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
                    ""id"": ""3e5c2da6-7c34-4cb7-bf00-5f354ad3a73e"",
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
                    ""id"": ""e332b6fd-4bb7-4c89-bc40-a317f0583e01"",
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
                    ""id"": ""437989d1-0a2f-4a70-8e84-c186151f116e"",
                    ""path"": ""<Gamepad>/dpad/down"",
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
                    ""id"": ""415ee4c5-df04-4ead-9dd7-f6000b51e143"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
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
                    ""id"": ""a6092aac-d5cd-4735-b7c6-a750b2960e1c"",
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
                    ""id"": ""520972c2-62aa-4737-9139-be78416f54f0"",
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
                    ""id"": ""850e52dd-0eaa-4469-865f-b0d86b0c5b91"",
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
                    ""id"": ""8859bdcb-b62d-493b-8bfb-7126b729bc59"",
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
                    ""id"": ""ac46e643-bb51-4cca-8fd4-b355e7c5e163"",
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
                    ""id"": ""4262ef49-6b50-404d-b938-5127c410ef50"",
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
                    ""id"": ""2b3886c3-93aa-4f51-9da0-c07ededa9380"",
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
                    ""id"": ""3bb86089-d0b5-437f-974d-24b4146956c7"",
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
                    ""id"": ""b99fb9c8-0c1b-4805-9682-c51204e7b4d3"",
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
                    ""id"": ""1fbfc762-5a61-4383-bbfc-2455c48ec5af"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""dd87d8c8-e775-4bd6-8bf9-989f6fa62e4d"",
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
                    ""id"": ""7a22b7d8-fbdd-48ec-ac04-fdfd78cba82e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bf75505b-0c88-4158-9d9b-7ae6d7417a33"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c7e5924d-151d-4d24-9d73-4ec86793d31d"",
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
                    ""id"": ""3f387163-a5e4-48cc-8db9-275ef0bcb270"",
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
                    ""id"": ""2fb98982-2527-4859-8dc4-c2e58431cf2b"",
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
                    ""id"": ""df006563-abec-4741-9bd0-17a3ae595c41"",
                    ""path"": ""<Gamepad>/dpad/down"",
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
            ""name"": ""Melee"",
            ""id"": ""1937122c-d389-4f84-b5b7-346cbc777f47"",
            ""actions"": [
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""eab055ee-e769-48ad-a793-66bf0d9fb70b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""de524571-1a93-4a6f-a1e3-6e227a413950"",
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
                    ""id"": ""103e978a-5476-4c9f-92ce-d0f5e2eff7af"",
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
                    ""id"": ""f826c6db-41c6-4fa2-ad48-d6724b1113b7"",
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
                    ""id"": ""59fdbfd4-d4a5-47ca-87fe-84e64d6dbdbf"",
                    ""path"": ""<Gamepad>/dpad/down"",
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
                    ""id"": ""625014ab-4be3-4877-9568-f743489a8d29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f7a0448f-ae2e-4a52-a5c7-7758e4b07fcf"",
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
                    ""id"": ""7da3b400-1c3a-4f48-b287-1cc3d50bef93"",
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
                    ""id"": ""5f6e9140-5f49-48cb-aa8a-15ef541b3000"",
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
                    ""id"": ""a99557f8-04f7-445d-a47f-52603a570ef2"",
                    ""path"": ""<Gamepad>/dpad/down"",
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
                    ""id"": ""c17829ff-6179-4f79-bd74-807f87149212"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fly"",
                    ""type"": ""Value"",
                    ""id"": ""9de49030-571b-4dbf-806f-b920a2d21663"",
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
                    ""id"": ""8b46c391-32b9-4d98-818a-59f197b4e295"",
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
                    ""id"": ""1c92b49b-f795-4023-ae11-2b66ffa46a32"",
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
                    ""id"": ""59f79061-24eb-4421-a8ff-853e6a0ac135"",
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
                    ""id"": ""80f41d97-28e5-4ae3-a3c4-4ebd30b3d8a7"",
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
                    ""id"": ""c9999fa8-fe08-4f78-a0d1-993cbde5f4e7"",
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
                    ""id"": ""db636890-7980-4a4f-9fe7-3d2840428d33"",
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
                    ""id"": ""17c83c5b-fabd-49f8-a10a-c25624b3309d"",
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
                    ""id"": ""4c5e5f7b-bc6b-4fda-963b-ae7383a8c86b"",
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
                    ""id"": ""2cf6086b-3b66-4f60-9554-fe16bc4598aa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""0e18ebc2-9112-412f-8e41-5317d6d6a566"",
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
                    ""id"": ""a7e99d95-40d5-4be6-9a24-cba42b441eea"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""21b8b764-4bc2-4a67-9e9e-6edf49c210f3"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""86d56669-25e0-4373-8959-545981a82ee4"",
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
                    ""id"": ""876fef93-d1ec-4090-a1d4-533e58862223"",
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
                    ""id"": ""443539ef-65fd-45cb-ae4e-4fcad414fc81"",
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
                    ""id"": ""27b13bdf-1332-4e8b-88aa-2e3754780381"",
                    ""path"": ""<Gamepad>/dpad/down"",
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
            ""name"": ""Tethering"",
            ""id"": ""3b2f34b8-5df5-4aaf-96c6-dc402eaa84eb"",
            ""actions"": [
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""0803ff80-3d32-4032-b0f6-b7e5fe4e584f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""031b06b1-4447-4f77-9eb0-6f9465aad499"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""65a8b3d3-44ec-4fc3-b768-dec95be24558"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootProjectile"",
                    ""type"": ""Button"",
                    ""id"": ""277a094f-1142-45a1-8b59-8ce5d09b1b54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Glide"",
                    ""type"": ""Button"",
                    ""id"": ""ae56e942-0c95-474b-b35e-434973db83df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fly"",
                    ""type"": ""Value"",
                    ""id"": ""918b6f37-4b3a-4d6a-852c-122c7d6aff81"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Untether"",
                    ""type"": ""Button"",
                    ""id"": ""9f5d97ed-fb7b-4eb2-a948-25e9b8781988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""debc0740-b64d-4cc7-8a1c-f4326ea22c45"",
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
                    ""id"": ""1a80fc0b-37db-4bc7-9498-8eca0fd39637"",
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
                    ""id"": ""5e961590-3ae5-438d-8dd8-371e08bccc34"",
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
                    ""id"": ""f884871e-2d67-40ec-9ef2-fbf9c458efec"",
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
                    ""id"": ""2f3868d2-46ed-4d1a-916f-1c6be43829bb"",
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
                    ""id"": ""ba82def5-6a71-47e2-a4ae-eb645336ba9a"",
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
                    ""id"": ""78aea51c-3ad3-4e79-a130-46144212d37f"",
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
                    ""id"": ""c2e4aae4-bacf-4c63-b8f7-7e7e33859fc5"",
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
                    ""id"": ""56a6b675-ce5e-4252-a7f6-e7f04be5eb04"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Untether"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9bfd9fc-87d9-475b-a9bc-1d78c43cfcc3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Untether"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""d660c9dd-6a11-493c-8f29-f2f3bfd70af4"",
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
                    ""id"": ""cb179aa4-8065-4610-b5e7-e54c57c29e13"",
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
                    ""id"": ""a061ca2d-9900-442f-ac16-14288968f035"",
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
                    ""id"": ""f0c710d4-b347-4df6-a700-e0e6b86fc80d"",
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
                    ""id"": ""43817e6b-02b8-4ae1-8764-0dffa14bd2b4"",
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
                    ""id"": ""9e97f193-1693-4577-b6d2-100e6cdfd566"",
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
                    ""id"": ""cb7bb505-395a-4cf4-9e23-08750ec16d83"",
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
                    ""id"": ""1e4feb58-8255-4db2-b812-85e394f2ed59"",
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
                    ""id"": ""aea899b9-5d0e-4e91-9b8e-db554fa2096a"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""f810ec9b-1d46-4b72-9572-b017f848b929"",
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
                    ""id"": ""a2739992-6ece-44b6-93a2-c15adf52185d"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ebd3066c-773d-44ec-838a-f835150b8b3a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ca1a59e8-f558-489e-97c6-57678c22d0be"",
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
                    ""id"": ""2d18856a-178f-4b37-ad92-c94646886c6c"",
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
                    ""id"": ""240cb756-8065-4bd5-bf46-6a0df981c238"",
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
                    ""id"": ""ae72819d-5afa-4919-9c8c-154aa9b298bf"",
                    ""path"": ""<Gamepad>/dpad/down"",
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
        // Tethering
        m_Tethering = asset.FindActionMap("Tethering", throwIfNotFound: true);
        m_Tethering_Dodge = m_Tethering.FindAction("Dodge", throwIfNotFound: true);
        m_Tethering_Jump = m_Tethering.FindAction("Jump", throwIfNotFound: true);
        m_Tethering_Melee = m_Tethering.FindAction("Melee", throwIfNotFound: true);
        m_Tethering_ShootProjectile = m_Tethering.FindAction("ShootProjectile", throwIfNotFound: true);
        m_Tethering_Glide = m_Tethering.FindAction("Glide", throwIfNotFound: true);
        m_Tethering_Fly = m_Tethering.FindAction("Fly", throwIfNotFound: true);
        m_Tethering_Untether = m_Tethering.FindAction("Untether", throwIfNotFound: true);
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

    // Tethering
    private readonly InputActionMap m_Tethering;
    private ITetheringActions m_TetheringActionsCallbackInterface;
    private readonly InputAction m_Tethering_Dodge;
    private readonly InputAction m_Tethering_Jump;
    private readonly InputAction m_Tethering_Melee;
    private readonly InputAction m_Tethering_ShootProjectile;
    private readonly InputAction m_Tethering_Glide;
    private readonly InputAction m_Tethering_Fly;
    private readonly InputAction m_Tethering_Untether;
    public struct TetheringActions
    {
        private @PlayerInputs m_Wrapper;
        public TetheringActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dodge => m_Wrapper.m_Tethering_Dodge;
        public InputAction @Jump => m_Wrapper.m_Tethering_Jump;
        public InputAction @Melee => m_Wrapper.m_Tethering_Melee;
        public InputAction @ShootProjectile => m_Wrapper.m_Tethering_ShootProjectile;
        public InputAction @Glide => m_Wrapper.m_Tethering_Glide;
        public InputAction @Fly => m_Wrapper.m_Tethering_Fly;
        public InputAction @Untether => m_Wrapper.m_Tethering_Untether;
        public InputActionMap Get() { return m_Wrapper.m_Tethering; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TetheringActions set) { return set.Get(); }
        public void SetCallbacks(ITetheringActions instance)
        {
            if (m_Wrapper.m_TetheringActionsCallbackInterface != null)
            {
                @Dodge.started -= m_Wrapper.m_TetheringActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_TetheringActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_TetheringActionsCallbackInterface.OnDodge;
                @Jump.started -= m_Wrapper.m_TetheringActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_TetheringActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_TetheringActionsCallbackInterface.OnJump;
                @Melee.started -= m_Wrapper.m_TetheringActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_TetheringActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_TetheringActionsCallbackInterface.OnMelee;
                @ShootProjectile.started -= m_Wrapper.m_TetheringActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.performed -= m_Wrapper.m_TetheringActionsCallbackInterface.OnShootProjectile;
                @ShootProjectile.canceled -= m_Wrapper.m_TetheringActionsCallbackInterface.OnShootProjectile;
                @Glide.started -= m_Wrapper.m_TetheringActionsCallbackInterface.OnGlide;
                @Glide.performed -= m_Wrapper.m_TetheringActionsCallbackInterface.OnGlide;
                @Glide.canceled -= m_Wrapper.m_TetheringActionsCallbackInterface.OnGlide;
                @Fly.started -= m_Wrapper.m_TetheringActionsCallbackInterface.OnFly;
                @Fly.performed -= m_Wrapper.m_TetheringActionsCallbackInterface.OnFly;
                @Fly.canceled -= m_Wrapper.m_TetheringActionsCallbackInterface.OnFly;
                @Untether.started -= m_Wrapper.m_TetheringActionsCallbackInterface.OnUntether;
                @Untether.performed -= m_Wrapper.m_TetheringActionsCallbackInterface.OnUntether;
                @Untether.canceled -= m_Wrapper.m_TetheringActionsCallbackInterface.OnUntether;
            }
            m_Wrapper.m_TetheringActionsCallbackInterface = instance;
            if (instance != null)
            {
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
                @Untether.started += instance.OnUntether;
                @Untether.performed += instance.OnUntether;
                @Untether.canceled += instance.OnUntether;
            }
        }
    }
    public TetheringActions @Tethering => new TetheringActions(this);
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
    public interface ITetheringActions
    {
        void OnDodge(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnShootProjectile(InputAction.CallbackContext context);
        void OnGlide(InputAction.CallbackContext context);
        void OnFly(InputAction.CallbackContext context);
        void OnUntether(InputAction.CallbackContext context);
    }
}
