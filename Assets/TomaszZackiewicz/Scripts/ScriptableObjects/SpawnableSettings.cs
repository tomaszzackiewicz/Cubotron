using UnityEngine;

namespace TZackiewicz {

    [CreateAssetMenu(fileName = "SpawnableSettings", menuName = "Settings/SpawnableSettings")]
    public class SpawnableSettings : ScriptableObject {

        [SerializeField]
        private float sizeMin = 0.0f;

        [SerializeField]
        private float sizeMax = 0.0f;

        [SerializeField]
        private float lifeTimeMin = 0.0f;

        [SerializeField]
        private float lifeTimeMax = 0.0f;


        public float SizeMin => sizeMin;

        public float SizeMax => sizeMax;

        public float LifeTimeMin => lifeTimeMin;

        public float LifeTimeMax => lifeTimeMax;

    }
}
