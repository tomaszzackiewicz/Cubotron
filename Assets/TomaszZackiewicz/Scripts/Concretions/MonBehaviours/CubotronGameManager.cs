using UnityEngine;

namespace TZackiewicz
{
    public class CubotronGameManager : Singleton<CubotronGameManager>
    {
        private void OnEnable()
        {
            QuitCommand.onQuit += Quit;
        }

        private void Quit()
        {
            Application.Quit();
        }

        private void OnDisable()
        {
            QuitCommand.onQuit -= Quit;
        }
    }
}
