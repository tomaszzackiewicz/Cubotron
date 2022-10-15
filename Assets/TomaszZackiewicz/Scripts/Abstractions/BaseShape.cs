using UnityEngine;

namespace TZackiewicz
{
    public abstract class BaseShape : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private ExplosionSettings explosionSettings = null;

        protected GameObject go = null;
        protected float timeStart = 0.0f;
        protected float returnToPoolTime = 0.0f;

        private ExplosionSettings _currentExplosionSettings = null;
        private MeshRenderer _meshRenderer = null;
        private Rigidbody _rigidBody = null;
        private bool _isExploded = false;

        public IObjectPool Orgin { get; set; }

        public float LifeTime{ get; set; }

        public Transform SpawnablesParentTransform { get; set; }

        public ShapeSpawner SpawnableSpawner { get; set; }

        public bool IsTimerStarted { get; set; } = false;

        public MeshRenderer MeshRenderer
        {
            get => _meshRenderer;
            set => _meshRenderer = value;
        }

        protected virtual void Awake()
        {
            if (explosionSettings)
            {
                _currentExplosionSettings = explosionSettings;
            }
            else
            {
                ErrorController.SetError(ErrorType.AddExplosionSettings);
            }

            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
            _rigidBody = gameObject.GetComponent<Rigidbody>();
        }

        protected virtual void OnEnable()
        {
            timeStart = 0.0f;
            returnToPoolTime = LifeTime;
            IsTimerStarted = true;
            ExplodeCommand.onExplode += Explode;
            ResetCommand.onReset += ResetShape;
        }

        protected virtual void Update()
        {
            SetTimer();
        }

        void SetTimer()
        {
            if (IsTimerStarted) {
                timeStart += Time.deltaTime;
                FadeObject(timeStart);
                if (timeStart >= returnToPoolTime)
                {
                    IsTimerStarted = false;
                    ReturnToPool();
                }
            }
            
        }

       private void FadeObject(float fadeValueParam)
       {
            Color color = _meshRenderer.material.color;
            //Debug.Log((fixationTime / fadeValueParam) / 10);
            color.a = returnToPoolTime / fadeValueParam / Consts.divider;
            _meshRenderer.material.color = color;
       }

        public void PrepareToUse(){}

        public void ReturnToPool()
        {
            Orgin.ReturnToPool(this.gameObject);

            if (!_isExploded) {
                RotatingCubeController rotatingCubeController = SpawnablesParentTransform.GetComponent<RotatingCubeController>();
                if (rotatingCubeController)
                {
                    rotatingCubeController.RespawnSpawnables(SpawnableSpawner);
                }
            }
        }

        private void ResetShape()
        {
            _isExploded = false;
        }

        private void Explode()
        {
            _isExploded = true;
            _rigidBody.isKinematic = false;
            _rigidBody.AddExplosionForce(
                _currentExplosionSettings.ExplosionForce, 
                SpawnablesParentTransform.position, 
                _currentExplosionSettings.ExplosionRadius, 
                _currentExplosionSettings.UpwardsModifies, 
                ForceMode.Impulse);
        }

        protected virtual void OnDisable()
        {
            ExplodeCommand.onExplode -= Explode;
            ResetCommand.onReset -= ResetShape;
        }
    }
}
