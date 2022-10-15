using UnityEngine;

namespace TZackiewicz
{
    public class InputController : MonoBehaviour
    {
        private CubotronActions _actions = null;
        private CubotronActions.GameActions _gameActions;

        private void OnEnable()
        {
            _actions = new CubotronActions();

            _gameActions = _actions.Game;

            _gameActions.Explode.performed += ctx => OnExplode();
            _gameActions.Reset.performed += ctx => OnReset();
            _gameActions.Quit.performed += ctx => OnQuit();

            _actions.Enable();
        }

        private void OnExplode()
        {
            Command explodeCommand = new ExplodeCommand();
            Invoker invoker = new Invoker();

            invoker.SetCommand(explodeCommand);
            invoker.ExecuteCommand();
        }

        private void OnReset()
        {
            Command resetCommand = new ResetCommand();
            Invoker invoker = new Invoker();

            invoker.SetCommand(resetCommand);
            invoker.ExecuteCommand();
        }

        private void OnQuit()
        {
            Command quitCommand = new QuitCommand();
            Invoker invoker = new Invoker();

            invoker.SetCommand(quitCommand);
            invoker.ExecuteCommand();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }
    }
}
