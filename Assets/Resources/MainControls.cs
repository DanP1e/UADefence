// GENERATED AUTOMATICALLY FROM 'Assets/Resources/MainControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""Global"",
            ""id"": ""82e619e6-0290-4039-ab7f-c6b9c70b6576"",
            ""actions"": [
                {
                    ""name"": ""MouseScreenPosition"",
                    ""type"": ""Value"",
                    ""id"": ""a02b6220-3d90-450d-bbcb-805c61622170"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CursorPress"",
                    ""type"": ""Button"",
                    ""id"": ""ff3c1f01-6524-4b08-af08-945316bb0773"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CursorRelease"",
                    ""type"": ""Button"",
                    ""id"": ""31f6cc7e-49f7-4309-9fbc-0649704165b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1d1a8013-397d-4e85-8075-f71debb8f491"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScreenPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b18a338-89f4-479a-8dfb-3248ee87769a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4205376b-7691-4bb7-b8b8-7e748a0b3f7e"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25d8c3df-f061-4a20-b0ef-9eb1f1c2f5d7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f65c4932-f305-4ce4-9e09-61609cafc43b"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_MouseScreenPosition = m_Global.FindAction("MouseScreenPosition", throwIfNotFound: true);
        m_Global_CursorPress = m_Global.FindAction("CursorPress", throwIfNotFound: true);
        m_Global_CursorRelease = m_Global.FindAction("CursorRelease", throwIfNotFound: true);
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

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_MouseScreenPosition;
    private readonly InputAction m_Global_CursorPress;
    private readonly InputAction m_Global_CursorRelease;
    public struct GlobalActions
    {
        private @MainControls m_Wrapper;
        public GlobalActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseScreenPosition => m_Wrapper.m_Global_MouseScreenPosition;
        public InputAction @CursorPress => m_Wrapper.m_Global_CursorPress;
        public InputAction @CursorRelease => m_Wrapper.m_Global_CursorRelease;
        public InputActionMap Get() { return m_Wrapper.m_Global; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalActions instance)
        {
            if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
            {
                @MouseScreenPosition.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMouseScreenPosition;
                @MouseScreenPosition.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMouseScreenPosition;
                @MouseScreenPosition.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnMouseScreenPosition;
                @CursorPress.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCursorPress;
                @CursorPress.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCursorPress;
                @CursorPress.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCursorPress;
                @CursorRelease.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCursorRelease;
                @CursorRelease.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCursorRelease;
                @CursorRelease.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnCursorRelease;
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseScreenPosition.started += instance.OnMouseScreenPosition;
                @MouseScreenPosition.performed += instance.OnMouseScreenPosition;
                @MouseScreenPosition.canceled += instance.OnMouseScreenPosition;
                @CursorPress.started += instance.OnCursorPress;
                @CursorPress.performed += instance.OnCursorPress;
                @CursorPress.canceled += instance.OnCursorPress;
                @CursorRelease.started += instance.OnCursorRelease;
                @CursorRelease.performed += instance.OnCursorRelease;
                @CursorRelease.canceled += instance.OnCursorRelease;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);
    public interface IGlobalActions
    {
        void OnMouseScreenPosition(InputAction.CallbackContext context);
        void OnCursorPress(InputAction.CallbackContext context);
        void OnCursorRelease(InputAction.CallbackContext context);
    }
}
