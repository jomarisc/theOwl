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
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""497b8976-2262-4631-8263-d2dad2400d26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5194048b-9486-4211-b1d9-92d07806daf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8d49d2ad-d454-4d37-bdcf-593f7c3f1f37"",
                    ""path"": ""<Keyboard>/e"",
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
                    ""interactions"": ""Press"",
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
                    ""path"": ""<Keyboard>/w"",
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
                    ""path"": ""<Keyboard>/j"",
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
                    ""id"": ""13ae88ae-4aca-4191-80c3-6b96ee94b38f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guntime"",
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
                    ""id"": ""64057694-dc6f-4d91-a9c4-8b2004cbb836"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseActiveSkill"",
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
                    ""name"": ""Arrow Keys"",
                    ""id"": ""14593019-704d-42bb-bcff-5879eb83946b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21e66f88-c8a4-47ff-aa5a-53e913e66708"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""018d639d-731e-48a5-b493-f08d0eed04e1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fd115648-38bc-43b0-a8a0-4cff2e0b4c14"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c2f0f4c2-f5a9-4ded-bbc5-5e593e2e799e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel"",
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
                    ""id"": ""1022b3c2-a2cc-4b57-96e7-b44739628fdf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenSkillWheel2"",
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
                    ""path"": ""<Keyboard>/q"",
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
                    ""path"": ""<Keyboard>/k"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""c8822063-c5a0-4286-979c-8a8c4f80959e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01827d74-23cc-4b25-96ec-c4a88dff9582"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa86d731-9d81-45c3-968c-4f5d397871fe"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""213e3898-9db9-40b7-8a15-69b7c0ca3faa"",
            ""actions"": [
                {
                    ""name"": ""Activate"",
                    ""type"": ""Button"",
                    ""id"": ""aee7061c-e908-4af8-bfdf-4e7c20b49c46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""8e61ab93-4aff-408f-8dfa-05df4cbd731e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b6ca588b-c2ae-455d-9750-d68eec160385"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressAnyButton"",
                    ""type"": ""PassThrough"",
                    ""id"": ""41a71a18-20ec-4999-aec2-7b78e74dd2c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9fe603fb-bd57-4e21-bc71-8ccab63af9c1"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6a1003c-a909-40f5-b592-35de74dd5fcb"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b541c36-ee7a-4f71-92bd-2c9299b12cf3"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c006c94f-81f5-49bd-8a68-52413dcc13b2"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""fa67edbe-0348-435d-9847-230777cfeabe"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2ca7378e-c420-4aad-b90c-d1b0af4779fc"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ac793ea7-ea40-462b-9e2d-b50085a51819"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f396a959-77cd-4f43-a0e3-e2d375cba4b5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""41ba7400-15a1-456e-a317-5adef6cf400a"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f87c0aa4-bfcb-41b2-945d-9869df68532e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50e414a3-be00-4820-9665-4914e10ab49e"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a20bfec9-fc6d-49c9-b268-e1c8b05c670d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""371e3269-73af-428d-a2cf-5f9c66a14cac"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c53b57d4-afd0-4ef5-a1cb-6c56b2a35f01"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""3f04e130-7362-4146-b045-3c34ff46d652"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""43fa3ca6-4ad7-4061-887f-95cd29db9fa7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""25f497d6-6f01-4a3c-8ee5-8b52bc7d9412"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""448d1aaf-ed45-4d48-9aff-ee81363091a0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""22693007-b47e-4d3c-abdb-776c582eb4e8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0e63998a-1b13-46d9-80dc-1269796ce87e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""51cf681a-d9ae-4f67-b743-aa8f118268c9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d642207f-6ea3-4cbc-a8b3-3cbf0408f958"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7e5366cd-a583-4c0c-8afa-3fe7b26f249d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""73b36930-aa7b-4447-888d-a268a93f6713"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c43d010-9ac9-4d9c-854e-11e61c7f0ac0"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""febc25f9-1d0a-4cc8-862f-c403d269f4ec"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""251caa7c-5943-411b-b77e-4889f6bae9e2"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""015ca3ee-812a-46e2-8e95-44747b6ce8ec"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressAnyButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SkillWheel"",
            ""id"": ""8c1a3e2a-4bcc-41af-a141-8641386cb2c0"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e403aeea-055e-4f79-815d-44659656455c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""83c8e86a-61e9-4962-b4ed-478ea94dcbc6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.075,max=0.925)"",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""650942e9-bc2b-44c5-aca2-7f279e794498"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7fd8d87a-451f-4ee0-8229-9934bbff6f6c"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fdb66bbc-10f8-4862-96aa-317767e3e74d"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b9afe16c-f411-4798-95f4-24f53c8612f5"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""506cc337-1604-4dad-adf9-9ca5118f6248"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""00d99779-2e36-4d16-b7d2-ced88b3961ad"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f93810eb-a92a-4cdc-b23c-d30b3f6a48b1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8bceb071-5965-4908-80f5-b7735fa3518c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""197169fc-9083-44ea-bc00-a8e932007360"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""249dd923-4ee8-4718-a600-51de0392a708"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Cutscene"",
            ""id"": ""00e99ca9-b0a0-4780-9b53-d0a88332f370"",
            ""actions"": [
                {
                    ""name"": ""Proceed"",
                    ""type"": ""Button"",
                    ""id"": ""12b9d214-59b3-46b7-83fc-9f83a61db333"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18b837e4-d8d5-45f0-8abd-2a1b283bc941"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Proceed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a8dfb3b-8a64-4937-bb96-c1fe0d1cb268"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Proceed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d488d88-4f4e-45aa-8538-9d3a72b86a33"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Proceed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f22b346-58da-4ed9-8b8c-29c989c07f19"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Proceed"",
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
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Activate = m_UI.FindAction("Activate", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_PressAnyButton = m_UI.FindAction("PressAnyButton", throwIfNotFound: true);
        // SkillWheel
        m_SkillWheel = asset.FindActionMap("SkillWheel", throwIfNotFound: true);
        m_SkillWheel_Navigate = m_SkillWheel.FindAction("Navigate", throwIfNotFound: true);
        // Cutscene
        m_Cutscene = asset.FindActionMap("Cutscene", throwIfNotFound: true);
        m_Cutscene_Proceed = m_Cutscene.FindAction("Proceed", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Interact;
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
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
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
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
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
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Activate;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_PressAnyButton;
    public struct UIActions
    {
        private @PlayerInputs m_Wrapper;
        public UIActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Activate => m_Wrapper.m_UI_Activate;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @PressAnyButton => m_Wrapper.m_UI_PressAnyButton;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Activate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnActivate;
                @Activate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnActivate;
                @Activate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnActivate;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @PressAnyButton.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPressAnyButton;
                @PressAnyButton.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPressAnyButton;
                @PressAnyButton.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPressAnyButton;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Activate.started += instance.OnActivate;
                @Activate.performed += instance.OnActivate;
                @Activate.canceled += instance.OnActivate;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @PressAnyButton.started += instance.OnPressAnyButton;
                @PressAnyButton.performed += instance.OnPressAnyButton;
                @PressAnyButton.canceled += instance.OnPressAnyButton;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // SkillWheel
    private readonly InputActionMap m_SkillWheel;
    private ISkillWheelActions m_SkillWheelActionsCallbackInterface;
    private readonly InputAction m_SkillWheel_Navigate;
    public struct SkillWheelActions
    {
        private @PlayerInputs m_Wrapper;
        public SkillWheelActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_SkillWheel_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_SkillWheel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SkillWheelActions set) { return set.Get(); }
        public void SetCallbacks(ISkillWheelActions instance)
        {
            if (m_Wrapper.m_SkillWheelActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_SkillWheelActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_SkillWheelActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_SkillWheelActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_SkillWheelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public SkillWheelActions @SkillWheel => new SkillWheelActions(this);

    // Cutscene
    private readonly InputActionMap m_Cutscene;
    private ICutsceneActions m_CutsceneActionsCallbackInterface;
    private readonly InputAction m_Cutscene_Proceed;
    public struct CutsceneActions
    {
        private @PlayerInputs m_Wrapper;
        public CutsceneActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Proceed => m_Wrapper.m_Cutscene_Proceed;
        public InputActionMap Get() { return m_Wrapper.m_Cutscene; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CutsceneActions set) { return set.Get(); }
        public void SetCallbacks(ICutsceneActions instance)
        {
            if (m_Wrapper.m_CutsceneActionsCallbackInterface != null)
            {
                @Proceed.started -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnProceed;
                @Proceed.performed -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnProceed;
                @Proceed.canceled -= m_Wrapper.m_CutsceneActionsCallbackInterface.OnProceed;
            }
            m_Wrapper.m_CutsceneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Proceed.started += instance.OnProceed;
                @Proceed.performed += instance.OnProceed;
                @Proceed.canceled += instance.OnProceed;
            }
        }
    }
    public CutsceneActions @Cutscene => new CutsceneActions(this);
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
        void OnPause(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnActivate(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnPressAnyButton(InputAction.CallbackContext context);
    }
    public interface ISkillWheelActions
    {
        void OnNavigate(InputAction.CallbackContext context);
    }
    public interface ICutsceneActions
    {
        void OnProceed(InputAction.CallbackContext context);
    }
}
