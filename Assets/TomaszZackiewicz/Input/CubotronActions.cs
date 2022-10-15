//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/TomaszZackiewicz/Input/CubotronActions.inputactions
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

public partial class @CubotronActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CubotronActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CubotronActions"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""e19af4de-e102-454a-86b4-16c8c7ec4262"",
            ""actions"": [
                {
                    ""name"": ""Explode"",
                    ""type"": ""Button"",
                    ""id"": ""eb803178-4483-43cd-9ecb-f0e41ea05cb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""032fe366-bd88-4387-9d7b-a1628802bb20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""5b2774e0-6ddf-4927-a43a-949662752976"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""076d2b04-a9b0-445e-85ea-830c7ca80f50"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Explode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faceed69-3a05-4f11-af91-bbaa9f99de69"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b6c8c97-e904-4f31-91ce-5df154330ae6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Explode = m_Game.FindAction("Explode", throwIfNotFound: true);
        m_Game_Quit = m_Game.FindAction("Quit", throwIfNotFound: true);
        m_Game_Reset = m_Game.FindAction("Reset", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Explode;
    private readonly InputAction m_Game_Quit;
    private readonly InputAction m_Game_Reset;
    public struct GameActions
    {
        private @CubotronActions m_Wrapper;
        public GameActions(@CubotronActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Explode => m_Wrapper.m_Game_Explode;
        public InputAction @Quit => m_Wrapper.m_Game_Quit;
        public InputAction @Reset => m_Wrapper.m_Game_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Explode.started -= m_Wrapper.m_GameActionsCallbackInterface.OnExplode;
                @Explode.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnExplode;
                @Explode.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnExplode;
                @Quit.started -= m_Wrapper.m_GameActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnQuit;
                @Reset.started -= m_Wrapper.m_GameActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Explode.started += instance.OnExplode;
                @Explode.performed += instance.OnExplode;
                @Explode.canceled += instance.OnExplode;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnExplode(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
}
