using System.Collections.Generic;
using UnityEngine;

namespace TZackiewicz
{
    public class RotatingCubeController : MonoBehaviour
    {
        [SerializeField]
        private bool isHidden = true;

        [SerializeField]
        private List<ShapeSpawner> _spawnableSpawners = new List<ShapeSpawner>();

        [SerializeField]
        private RotatingCubeSettings rotatingCubeSettings = null;

        private BoxCollider _col = null;
        private MeshRenderer _renderer = null;
        private bool _canRotate = true;
        private RotatingCubeSettings _currentRotatingCubeSettings = null;

        private void Awake()
        {
            if (rotatingCubeSettings)
            {
                _currentRotatingCubeSettings = rotatingCubeSettings;
            }
            else
            {
                ErrorController.SetError(ErrorType.AddRotatingCubeSettings);
            }

            _col = gameObject.GetComponent<BoxCollider>();
            _renderer = gameObject.GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            ExplodeCommand.onExplode += StopRotation;
            ResetCommand.onReset += StartRotation;
        }

        void Start()
        {
            if (isHidden)
            {
                _renderer.enabled = false;
            }
            SpawnSpawnables();
        }

        private void SpawnSpawnables()
        {
            foreach (var _spawnableSpawner in _spawnableSpawners)
            {
                _spawnableSpawner.SpawnSpawnables(this.gameObject.transform, _col, _currentRotatingCubeSettings.AmountOfSpawnables);
            }
        }

        public void RespawnSpawnables(ShapeSpawner spawnableSpawnerParam)
        {
            spawnableSpawnerParam.RespawnSpawnables(this.gameObject.transform, _col);
        }

        void Update()
        {
            if (_canRotate) {
                Rotate();
            }
        }

        private void Rotate()
        {
            gameObject.transform.Rotate(_currentRotatingCubeSettings.RotationAngle);
        }

        private void StartRotation()
        {
            _canRotate = true;
            SpawnSpawnables();
        }

        private void StopRotation()
        {
            _canRotate = false;
        }

        private void OnDisable()
        {
            ExplodeCommand.onExplode -= StopRotation;
            ResetCommand.onReset -= StartRotation;
        }
    }

}
