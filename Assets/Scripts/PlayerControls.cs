// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""HookControls"",
            ""id"": ""7bcb1279-a976-4d3c-ad2e-26a2f69e52f4"",
            ""actions"": [
                {
                    ""name"": ""StickMovement"",
                    ""type"": ""Value"",
                    ""id"": ""d4b088d7-fffd-4c59-bc22-c78605dd4e29"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseMovement"",
                    ""type"": ""Value"",
                    ""id"": ""e210e082-d11c-427f-8bc7-3aa323978953"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ca3dee8b-5cbf-4fb6-ba7d-2e1a6096882b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StickMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0784eed5-188f-4ed7-9acd-599181c48c44"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // HookControls
        m_HookControls = asset.FindActionMap("HookControls", throwIfNotFound: true);
        m_HookControls_StickMovement = m_HookControls.FindAction("StickMovement", throwIfNotFound: true);
        m_HookControls_MouseMovement = m_HookControls.FindAction("MouseMovement", throwIfNotFound: true);
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

    // HookControls
    private readonly InputActionMap m_HookControls;
    private IHookControlsActions m_HookControlsActionsCallbackInterface;
    private readonly InputAction m_HookControls_StickMovement;
    private readonly InputAction m_HookControls_MouseMovement;
    public struct HookControlsActions
    {
        private @PlayerControls m_Wrapper;
        public HookControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @StickMovement => m_Wrapper.m_HookControls_StickMovement;
        public InputAction @MouseMovement => m_Wrapper.m_HookControls_MouseMovement;
        public InputActionMap Get() { return m_Wrapper.m_HookControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HookControlsActions set) { return set.Get(); }
        public void SetCallbacks(IHookControlsActions instance)
        {
            if (m_Wrapper.m_HookControlsActionsCallbackInterface != null)
            {
                @StickMovement.started -= m_Wrapper.m_HookControlsActionsCallbackInterface.OnStickMovement;
                @StickMovement.performed -= m_Wrapper.m_HookControlsActionsCallbackInterface.OnStickMovement;
                @StickMovement.canceled -= m_Wrapper.m_HookControlsActionsCallbackInterface.OnStickMovement;
                @MouseMovement.started -= m_Wrapper.m_HookControlsActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.performed -= m_Wrapper.m_HookControlsActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.canceled -= m_Wrapper.m_HookControlsActionsCallbackInterface.OnMouseMovement;
            }
            m_Wrapper.m_HookControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StickMovement.started += instance.OnStickMovement;
                @StickMovement.performed += instance.OnStickMovement;
                @StickMovement.canceled += instance.OnStickMovement;
                @MouseMovement.started += instance.OnMouseMovement;
                @MouseMovement.performed += instance.OnMouseMovement;
                @MouseMovement.canceled += instance.OnMouseMovement;
            }
        }
    }
    public HookControlsActions @HookControls => new HookControlsActions(this);
    public interface IHookControlsActions
    {
        void OnStickMovement(InputAction.CallbackContext context);
        void OnMouseMovement(InputAction.CallbackContext context);
    }
}
