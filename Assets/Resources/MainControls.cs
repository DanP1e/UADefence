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
            ""name"": ""Units"",
            ""id"": ""cf2a0147-c68c-4ab7-90cb-2c6aae469e14"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""edf95c20-1e9f-4272-b72a-98549559d7c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d282783-06fa-4c48-972d-c0e30fee5617"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Units
        m_Units = asset.FindActionMap("Units", throwIfNotFound: true);
        m_Units_Shoot = m_Units.FindAction("Shoot", throwIfNotFound: true);
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_MouseScreenPosition = m_Global.FindAction("MouseScreenPosition", throwIfNotFound: true);
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

    // Units
    private readonly InputActionMap m_Units;
    private IUnitsActions m_UnitsActionsCallbackInterface;
    private readonly InputAction m_Units_Shoot;
    public struct UnitsActions
    {
        private @MainControls m_Wrapper;
        public UnitsActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Units_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Units; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UnitsActions set) { return set.Get(); }
        public void SetCallbacks(IUnitsActions instance)
        {
            if (m_Wrapper.m_UnitsActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_UnitsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_UnitsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_UnitsActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_UnitsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public UnitsActions @Units => new UnitsActions(this);

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_MouseScreenPosition;
    public struct GlobalActions
    {
        private @MainControls m_Wrapper;
        public GlobalActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseScreenPosition => m_Wrapper.m_Global_MouseScreenPosition;
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
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseScreenPosition.started += instance.OnMouseScreenPosition;
                @MouseScreenPosition.performed += instance.OnMouseScreenPosition;
                @MouseScreenPosition.canceled += instance.OnMouseScreenPosition;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);
    public interface IUnitsActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IGlobalActions
    {
        void OnMouseScreenPosition(InputAction.CallbackContext context);
    }
}
