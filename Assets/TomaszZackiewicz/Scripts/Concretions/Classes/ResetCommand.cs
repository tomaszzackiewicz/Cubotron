using System;

namespace TZackiewicz
{
    public class ResetCommand : Command
    {
        public static Action onReset = null;

        public override void Execute()
        {
            onReset?.Invoke();
        }
    }
}
