using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic implementation object of pool 
/// </summary>
/// 
namespace TZackiewicz
{
    public class ObjectPool : IObjectPool
    {
        private Stack<GameObject> _reusableInstances = new Stack<GameObject>();

        public GameObject GetPrefabInstance(GameObject goParam, Vector3 positionParam, Vector3 rotationParam, Vector3 scaleParam)
        {
            GameObject inst;

            if (_reusableInstances.Count > 0)
            {
                inst = _reusableInstances.Pop();
                inst.gameObject.SetActive(true);
            }
            else
            {
                inst = GameObject.Instantiate(goParam);
            }

            IPoolable iPoolable = inst.GetComponent<IPoolable>();

            if (iPoolable != null)
            {
                iPoolable.Orgin = this;
                iPoolable.PrepareToUse();
            }

            return inst;
        }

        public void ReturnToPool(GameObject inst)
        {
            inst.gameObject.SetActive(false);
            inst.transform.localPosition = Vector3.zero;
            inst.transform.localScale = Vector3.one;
            inst.transform.localEulerAngles = Vector3.one;

            _reusableInstances.Push(inst);
        }

    }
}
