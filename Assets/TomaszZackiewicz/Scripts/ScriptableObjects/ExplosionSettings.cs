using UnityEngine;

namespace TZackiewicz
{
    [CreateAssetMenu(fileName = "ExplosionSettings", menuName = "Settings/ExplosionSettings")]
    public class ExplosionSettings : ScriptableObject
    {

        [SerializeField]
        private float explosionForce = 1000.0f;

        [SerializeField]
        private float explosionRadius = 10.0f;

        [SerializeField]
        private float upwardsModifies = 50.0f;

     

        public float ExplosionForce => explosionForce;

        public float ExplosionRadius => explosionRadius;

        public float UpwardsModifies => upwardsModifies;

      
    }
}
