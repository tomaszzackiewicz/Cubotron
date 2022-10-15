using UnityEngine;

public class GetPointInVolume: MonoBehaviour
{
    [SerializeField]
    private LayerMask spawnedObjectLayer;

    [SerializeField]
    Collider[] collidersInsideOverlapBox = null;

    private bool _canBeSpawn = false;

    public Vector3 GetRandomPointInVolume(Bounds boundsParam)
    {
       
        Vector3 randomPoint = Vector3.zero;
        //int safetyLoop = 0;
        //_canBeSpawn = false;

        //while (!_canBeSpawn)
        //{
        //    float offsetX = UnityEngine.Random.Range(-boundsParam.extents.x / 1.5f / 10, boundsParam.extents.x / 1.5f / 10);
        //    float offsetY = UnityEngine.Random.Range(-boundsParam.extents.y / 1.5f / 10, boundsParam.extents.y / 1.5f / 10);
        //    float offsetZ = UnityEngine.Random.Range(-boundsParam.extents.z / 1.5f / 10, boundsParam.extents.z / 1.5f / 10);
        //    randomPoint = boundsParam.center + new Vector3(offsetX, offsetY, offsetZ);

        //    _canBeSpawn = CheckIfCanBeSpawn(randomPoint, boundsParam.size);
        //    Debug.Log(_canBeSpawn);
        //    if (_canBeSpawn)
        //    {
        //        break;
        //    }

        //    safetyLoop++;

        //    if(safetyLoop >= 50)
        //    {
        //        break;
        //    }
        //}

        float offsetX = UnityEngine.Random.Range(-boundsParam.extents.x / 1.5f / 10, boundsParam.extents.x / 1.5f / 10);
        float offsetY = UnityEngine.Random.Range(-boundsParam.extents.y / 1.5f / 10, boundsParam.extents.y / 1.5f / 10);
        float offsetZ = UnityEngine.Random.Range(-boundsParam.extents.z / 1.5f / 10, boundsParam.extents.z / 1.5f / 10);
        randomPoint = boundsParam.center + new Vector3(offsetX, offsetY, offsetZ);

        return randomPoint;
    }

    private bool CheckIfCanBeSpawn(Vector3 randomPointParam, Vector3 overlapTestBoxSizeParam)
    {
        int numberOfCollidersFound = 0;

        Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, randomPointParam);

        Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSizeParam.x / 10, overlapTestBoxSizeParam.y / 10, overlapTestBoxSizeParam.z / 10);
        collidersInsideOverlapBox = new Collider[100];
        

        numberOfCollidersFound = Physics.OverlapBoxNonAlloc(randomPointParam, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);
        Debug.Log(numberOfCollidersFound);
        return (numberOfCollidersFound > 0) ? false : true;
    }
}
