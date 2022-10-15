using UnityEngine;

namespace TZackiewicz
{
    public class ErrorController : MonoBehaviour
    {
        public static void SetError(ErrorType errorTypeParam)
        {
            switch (errorTypeParam)
            {
                case ErrorType.TypeOfShape:
                    ProcessError(Consts.typeOfShape);
                    break;
                case ErrorType.AddSpawnableSettings:
                    ProcessError(Consts.addSpawnableSettings);
                    break;
                case ErrorType.AddRotatingCubeSettings:
                    ProcessError(Consts.addRotatingCubeSettings);
                    break;
                case ErrorType.AddExplosionSettings:
                    ProcessError(Consts.addExplosionSettings);
                    break;
            }
        }

        private static void ProcessError(string errorParam)
        {
            Debug.LogError(errorParam);
        }
    }
}
