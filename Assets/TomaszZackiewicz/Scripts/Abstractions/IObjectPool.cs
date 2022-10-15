using UnityEngine;
/// <summary>
/// Base interface for object pool used in poolable objects
/// </summary>
public interface IObjectPool
{
    void ReturnToPool(GameObject instance);
}
