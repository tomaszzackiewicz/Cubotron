using System;

namespace TZackiewicz
{
    public class ExplodeCommand : Command
    {
        public static Action onExplode = null;

        public override void Execute()
        {
            onExplode?.Invoke();
        }
    }
}
