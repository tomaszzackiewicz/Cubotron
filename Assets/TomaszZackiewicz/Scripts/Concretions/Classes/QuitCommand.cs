using System;

namespace TZackiewicz
{
    public class QuitCommand : Command
    {
        public static Action onQuit = null;

        public override void Execute()
        {
            onQuit?.Invoke();
        }
    }
}
