using UnityEngine;

namespace TZackiewicz
{
    public abstract class BaseShapeClass
    {
        public GameObject GetSpawnable(string pathToPrefabParam)
        {
            return Resources.Load<GameObject>(pathToPrefabParam);
        }

        public Vector3 SetRandomSpawnPosition(Bounds boundsParam, Transform spawnablesParentTransformParam)
        {

            Vector3 randomPoint = Vector3.zero;
            float padding = spawnablesParentTransformParam.localScale.x + Consts.margin;

            float offsetX = Random.Range(-boundsParam.extents.x / padding, boundsParam.extents.x / padding);
            float offsetY = Random.Range(-boundsParam.extents.y / padding, boundsParam.extents.y / padding);
            float offsetZ = Random.Range(-boundsParam.extents.z / padding, boundsParam.extents.z / padding);

            randomPoint = boundsParam.center + new Vector3(offsetX, offsetY, offsetZ);

            return randomPoint;
        }

        public float SetRandomSpawnSize(float minSizeParam, float maxSizeParam)
        {
            return Random.Range(minSizeParam, maxSizeParam);
        }

        public float  SetRandomSpawnLifetime(float minTimeParam, float maxTimeParam)
        {
            return Random.Range(minTimeParam, maxTimeParam);
        }

        public Material SetRandomSpawnColor(MeshRenderer meshRendererParam)
        {
            Material mat = meshRendererParam.material;
            Color color = mat.GetColor(Consts.baseColor);

            color.r = Random.Range(Consts.minColorRange, Consts.maxColorRange);
            color.g = Random.Range(Consts.minColorRange, Consts.maxColorRange);
            color.b = Random.Range(Consts.minColorRange, Consts.maxColorRange);

            mat.SetColor(Consts.baseColor, color);

            return mat;
        }
    }
}
