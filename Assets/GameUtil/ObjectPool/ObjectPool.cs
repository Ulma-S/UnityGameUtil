using System.Collections.Generic;
using UnityEngine;

namespace ulma
{
    /// <summary>
    /// PoolElementの生成を管理するクラス．
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : ObjectPoolElement
    {
        private readonly ObjectPoolData _PoolData;
        private readonly GameObject _Anchor;

        private readonly Queue<ObjectPoolElement> _InstantiatedObjects = new Queue<ObjectPoolElement>();

        public ObjectPool(ObjectPoolData poolData, GameObject anchor)
        {
            _PoolData = poolData;
            _Anchor = anchor;
        }


        #region public methods

        /// <summary>
        /// PoolElementを生成．
        /// 生成上限の場合は，既に生成されているPoolElementが返ります．
        /// </summary>
        /// <returns></returns>
        public T Generate()
        {
            var obj = _InstantiatedObjects.Dequeue();

            if (obj.IsActive)
            {
                Debug.LogError("[ObjectPool] " + _PoolData.Prefab.name + "は生成上限です！");
            }

            obj.Activate();

            _InstantiatedObjects.Enqueue(obj);

            return obj as T;
        }


        /// <summary>
        /// PoolElementを生成．
        /// 生成上限の場合は，既に生成されているPoolElementが返ります．
        /// </summary>
        /// <param name="position">生成時の座標</param>
        /// <param name="rotation">生成時の回転</param>
        /// <returns></returns>
        public T Generate(Vector3 position, Quaternion rotation)
        {
            var obj = Generate();

            obj.transform.position = position;
            obj.transform.rotation = rotation;

            return obj;
        }


        /// <summary>
        /// PoolElementの初期生成．
        /// </summary>
        public void InitialGenerate()
        {
            var maxCount = _PoolData.MaxCount;

            for(int i=0; i<maxCount; i++)
            {
                var obj = Object.Instantiate(_PoolData.Prefab);
                var element = obj.GetComponent<ObjectPoolElement>();

                if(element == null)
                {
#if UNITY_EDITOR
                    Debug.LogError("[ObjectPool] 設定されているPrefabにObjectPoolElement Componentが存在しません！");
#endif
                    break;
                }

                var castElement = element as T;
                if(castElement == null)
                {
                    Debug.LogError("[ObjectPool] 設定されているPrefabに" + typeof(T) + "型のObjectPoolElement Componentが存在しません！");
                    Object.Destroy(castElement);
                    return;
                }

                if(_Anchor != null)
                {
                    element.transform.parent = _Anchor.transform;
                }

                element.Initialize();

                _InstantiatedObjects.Enqueue(element);
            }
        }
        #endregion
    }
}