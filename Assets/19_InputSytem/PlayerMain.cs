//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/19_InputSytem/PlayerMain.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerMain: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMain()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMain"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2e8e4b9e-5a90-490b-a13c-028636555112"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b37b58b0-f6c1-40b2-9736-8dcea8ed5c94"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""1b276ec8-0572-403f-8ad2-a30298bb4d20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shift"",
                    ""type"": ""Button"",
                    ""id"": ""e9aec74a-b269-4c5d-8c96-fdbd3635b636"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Control"",
                    ""type"": ""Button"",
                    ""id"": ""e0b2436d-bae9-4f32-b8d9-7ab267cd8657"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""30454ad4-cdf0-4fff-8100-b59b231995f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseRightClick"",
                    ""type"": ""Button"",
                    ""id"": ""1ce553e0-ff0e-4744-bbba-5204ea02267d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Q_Click"",
                    ""type"": ""Button"",
                    ""id"": ""e4d57010-4bc4-4db1-bf5f-4beca328602d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""E_Click"",
                    ""type"": ""Button"",
                    ""id"": ""1c178cda-696a-44d6-9e48-1007849eefc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""R_Click"",
                    ""type"": ""Button"",
                    ""id"": ""181f62fa-d413-4cc0-9ab5-faff1244ee72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Tab"",
                    ""type"": ""Button"",
                    ""id"": ""ee5054e8-c899-45b1-b7c2-335f660631f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ESC"",
                    ""type"": ""Button"",
                    ""id"": ""a858e651-0adf-4eee-af1c-36ead3d88188"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d47d48cf-c73f-4c47-aec1-2ad796f8c0af"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""169932ea-4da8-46c5-99ff-dc3bc557b401"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""20868839-bf6d-477f-828a-9f849be007fa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""433d804e-6956-4016-889f-6217712d63d9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dd0b5353-57f7-4c4e-9b17-32fd3c330b0e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6f428507-35b8-4333-8329-f4017a4a1c61"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a9e3b1f-43c7-4736-9bb0-9a5aee343c66"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67a5003f-ed12-4f0a-9003-6cafc952e004"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8c7b71c-84fc-4e67-8e7e-9901f18cff1a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00375966-4c59-4967-be1e-5cf306339578"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q_Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""684d04af-cd4c-489c-8fc4-47347538c3cf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f07d8906-2da8-4c37-ab13-4b1152ba194e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E_Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c077889-814a-48a3-9b22-61d94b963ec6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R_Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d09f190-ea75-4dce-bcbb-a8a7252ede42"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ccd2c01-66ba-46ac-ae12-97873f56a0c6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ESC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Space = m_Player.FindAction("Space", throwIfNotFound: true);
        m_Player_Shift = m_Player.FindAction("Shift", throwIfNotFound: true);
        m_Player_Control = m_Player.FindAction("Control", throwIfNotFound: true);
        m_Player_MouseLeftClick = m_Player.FindAction("MouseLeftClick", throwIfNotFound: true);
        m_Player_MouseRightClick = m_Player.FindAction("MouseRightClick", throwIfNotFound: true);
        m_Player_Q_Click = m_Player.FindAction("Q_Click", throwIfNotFound: true);
        m_Player_E_Click = m_Player.FindAction("E_Click", throwIfNotFound: true);
        m_Player_R_Click = m_Player.FindAction("R_Click", throwIfNotFound: true);
        m_Player_Tab = m_Player.FindAction("Tab", throwIfNotFound: true);
        m_Player_ESC = m_Player.FindAction("ESC", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Space;
    private readonly InputAction m_Player_Shift;
    private readonly InputAction m_Player_Control;
    private readonly InputAction m_Player_MouseLeftClick;
    private readonly InputAction m_Player_MouseRightClick;
    private readonly InputAction m_Player_Q_Click;
    private readonly InputAction m_Player_E_Click;
    private readonly InputAction m_Player_R_Click;
    private readonly InputAction m_Player_Tab;
    private readonly InputAction m_Player_ESC;
    public struct PlayerActions
    {
        private @PlayerMain m_Wrapper;
        public PlayerActions(@PlayerMain wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Space => m_Wrapper.m_Player_Space;
        public InputAction @Shift => m_Wrapper.m_Player_Shift;
        public InputAction @Control => m_Wrapper.m_Player_Control;
        public InputAction @MouseLeftClick => m_Wrapper.m_Player_MouseLeftClick;
        public InputAction @MouseRightClick => m_Wrapper.m_Player_MouseRightClick;
        public InputAction @Q_Click => m_Wrapper.m_Player_Q_Click;
        public InputAction @E_Click => m_Wrapper.m_Player_E_Click;
        public InputAction @R_Click => m_Wrapper.m_Player_R_Click;
        public InputAction @Tab => m_Wrapper.m_Player_Tab;
        public InputAction @ESC => m_Wrapper.m_Player_ESC;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Space.started += instance.OnSpace;
            @Space.performed += instance.OnSpace;
            @Space.canceled += instance.OnSpace;
            @Shift.started += instance.OnShift;
            @Shift.performed += instance.OnShift;
            @Shift.canceled += instance.OnShift;
            @Control.started += instance.OnControl;
            @Control.performed += instance.OnControl;
            @Control.canceled += instance.OnControl;
            @MouseLeftClick.started += instance.OnMouseLeftClick;
            @MouseLeftClick.performed += instance.OnMouseLeftClick;
            @MouseLeftClick.canceled += instance.OnMouseLeftClick;
            @MouseRightClick.started += instance.OnMouseRightClick;
            @MouseRightClick.performed += instance.OnMouseRightClick;
            @MouseRightClick.canceled += instance.OnMouseRightClick;
            @Q_Click.started += instance.OnQ_Click;
            @Q_Click.performed += instance.OnQ_Click;
            @Q_Click.canceled += instance.OnQ_Click;
            @E_Click.started += instance.OnE_Click;
            @E_Click.performed += instance.OnE_Click;
            @E_Click.canceled += instance.OnE_Click;
            @R_Click.started += instance.OnR_Click;
            @R_Click.performed += instance.OnR_Click;
            @R_Click.canceled += instance.OnR_Click;
            @Tab.started += instance.OnTab;
            @Tab.performed += instance.OnTab;
            @Tab.canceled += instance.OnTab;
            @ESC.started += instance.OnESC;
            @ESC.performed += instance.OnESC;
            @ESC.canceled += instance.OnESC;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Space.started -= instance.OnSpace;
            @Space.performed -= instance.OnSpace;
            @Space.canceled -= instance.OnSpace;
            @Shift.started -= instance.OnShift;
            @Shift.performed -= instance.OnShift;
            @Shift.canceled -= instance.OnShift;
            @Control.started -= instance.OnControl;
            @Control.performed -= instance.OnControl;
            @Control.canceled -= instance.OnControl;
            @MouseLeftClick.started -= instance.OnMouseLeftClick;
            @MouseLeftClick.performed -= instance.OnMouseLeftClick;
            @MouseLeftClick.canceled -= instance.OnMouseLeftClick;
            @MouseRightClick.started -= instance.OnMouseRightClick;
            @MouseRightClick.performed -= instance.OnMouseRightClick;
            @MouseRightClick.canceled -= instance.OnMouseRightClick;
            @Q_Click.started -= instance.OnQ_Click;
            @Q_Click.performed -= instance.OnQ_Click;
            @Q_Click.canceled -= instance.OnQ_Click;
            @E_Click.started -= instance.OnE_Click;
            @E_Click.performed -= instance.OnE_Click;
            @E_Click.canceled -= instance.OnE_Click;
            @R_Click.started -= instance.OnR_Click;
            @R_Click.performed -= instance.OnR_Click;
            @R_Click.canceled -= instance.OnR_Click;
            @Tab.started -= instance.OnTab;
            @Tab.performed -= instance.OnTab;
            @Tab.canceled -= instance.OnTab;
            @ESC.started -= instance.OnESC;
            @ESC.performed -= instance.OnESC;
            @ESC.canceled -= instance.OnESC;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void OnShift(InputAction.CallbackContext context);
        void OnControl(InputAction.CallbackContext context);
        void OnMouseLeftClick(InputAction.CallbackContext context);
        void OnMouseRightClick(InputAction.CallbackContext context);
        void OnQ_Click(InputAction.CallbackContext context);
        void OnE_Click(InputAction.CallbackContext context);
        void OnR_Click(InputAction.CallbackContext context);
        void OnTab(InputAction.CallbackContext context);
        void OnESC(InputAction.CallbackContext context);
    }
}
