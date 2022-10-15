using UnityEngine;

namespace TZackiewicz {

    [CreateAssetMenu(fileName = "RotatingCubeSettings", menuName = "Settings/RotatingCubeSettings")]
    public class RotatingCubeSettings : ScriptableObject {

        [SerializeField]
        private Vector3 rotationAngle = Vector3.zero;

        [SerializeField]
        private int amountOfSpawnables = 0;


        public Vector3 RotationAngle => rotationAngle;

        public int AmountOfSpawnables => amountOfSpawnables;
    }
}
