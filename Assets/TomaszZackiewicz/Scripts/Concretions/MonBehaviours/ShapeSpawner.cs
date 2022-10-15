using System.Collections.Generic;
using UnityEngine;

namespace TZackiewicz
{
    public class ShapeSpawner : MonoBehaviour
    {
        [SerializeField]
        private SpawnableType spawnableType = SpawnableType.None;

        [SerializeField]
        private string pathToPrefab = "";

        [SerializeField]
        private SpawnableSettings spawnableSettings = null;

        private List<GameObject> _spawnedShapes = new List<GameObject>();
        private SpawnableSettings _currentSpawnableSettings = null;
        private Transform _spawnablesParentTransform = null;
        private ObjectPool _objectPool = null;
        private ShapeFactory spawnableFactory = null;

        private void Awake()
        {
            if (spawnableSettings)
            {
                _currentSpawnableSettings = spawnableSettings;
            }
            else
            {
                ErrorController.SetError(ErrorType.AddSpawnableSettings);
            }

            _objectPool = new ObjectPool();
            spawnableFactory = new ShapeFactory();
        }

        public void SpawnSpawnables(Transform parentParam, Collider colParam, int amountOfSpawnablesParam)
        {
            _spawnablesParentTransform = parentParam;
            int _spawnableCounter = 0;

            if (_spawnedShapes.Count >= amountOfSpawnablesParam)
            {
                foreach (var go in _spawnedShapes)
                {
                    go.SetActive(true);
                    Rigidbody rb = go.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        rb.isKinematic = true;
                    }
                    ReviveSpawnableShapes(go, parentParam, colParam);
                }
            }
            else
            {
                while (_spawnableCounter < amountOfSpawnablesParam)
                {
                    Spawn(parentParam, colParam);

                    _spawnableCounter++;
                }
            }
        }

        private void ReviveSpawnableShapes(GameObject goParam, Transform parentParam, Collider colParam)
        {
            BaseShapeClass spawnableBase = spawnableFactory.GetSpawnableBase(spawnableType);
            SetSpawnableShapeProperties(goParam, spawnableBase, parentParam, colParam);
        }

        public void RespawnSpawnables(Transform parentParam, Collider colParam)
        {
            Spawn(parentParam, colParam);
        }

        private void Spawn(Transform parentParam, Collider colParam)
        {
            Vector3 position = Vector3.zero;
            Vector3 rotation = Vector3.zero;
            Vector3 scale = Vector3.zero;
            
            BaseShapeClass spawnableBase = spawnableFactory.GetSpawnableBase(spawnableType);
            GameObject go = spawnableBase.GetSpawnable(pathToPrefab);

            if (spawnableBase != null)
            {
                GameObject spawnendShape = _objectPool.GetPrefabInstance(go, position, rotation, scale);
                if (spawnendShape != null)
                {
                    SetSpawnableShapeProperties(spawnendShape, spawnableBase, parentParam, colParam);
                }
            }
        }

        private void SetSpawnableShapeProperties(GameObject spawnendShapeParam, BaseShapeClass spawnableBaseParam, Transform parentParam, Collider colParam)
        {
            float size = 0.0f;
            float lifeTime = 0.0f;
            Vector3 position = Vector3.zero;

            position = spawnableBaseParam.SetRandomSpawnPosition(colParam.bounds, _spawnablesParentTransform);
            size = spawnableBaseParam.SetRandomSpawnSize(_currentSpawnableSettings.SizeMin, _currentSpawnableSettings.SizeMax);
            lifeTime = spawnableBaseParam.SetRandomSpawnLifetime(_currentSpawnableSettings.LifeTimeMin, _currentSpawnableSettings.LifeTimeMax);

            if (spawnendShapeParam)
            {
                spawnendShapeParam.transform.SetParent(parentParam);
                spawnendShapeParam.transform.localPosition = position;
                spawnendShapeParam.transform.localEulerAngles = Vector3.one;
                spawnendShapeParam.transform.localScale = new Vector3(size, size, size);

                BaseShape spawnedBase = spawnendShapeParam.GetComponent<BaseShape>();
                if (spawnedBase)
                {
                    spawnedBase.LifeTime = lifeTime;
                    spawnedBase.SpawnableSpawner = this;
                    spawnedBase.SpawnablesParentTransform = _spawnablesParentTransform;
                    Material mat = spawnableBaseParam.SetRandomSpawnColor(spawnedBase.MeshRenderer);
                    spawnedBase.MeshRenderer.sharedMaterial = mat;

                    if (!_spawnedShapes.Contains(spawnendShapeParam))
                    {
                        _spawnedShapes.Add(spawnendShapeParam);
                    }
                }
            }
        }
    }

}
