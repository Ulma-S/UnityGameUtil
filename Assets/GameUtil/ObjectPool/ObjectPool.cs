using System.Collections.Generic;
using UnityEngine;

namespace ulma
{
    /// <summary>
    /// PoolElement�̐������Ǘ�����N���X�D
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
        /// PoolElement�𐶐��D
        /// ��������̏ꍇ�́C���ɐ�������Ă���PoolElement���Ԃ�܂��D
        /// </summary>
        /// <returns></returns>
        public T Generate()
        {
            var obj = _InstantiatedObjects.Dequeue();

            if (obj.IsActive)
            {
                Debug.LogError("[ObjectPool] " + _PoolData.Prefab.name + "�͐�������ł��I");
            }

            obj.Activate();

            _InstantiatedObjects.Enqueue(obj);

            return obj as T;
        }


        /// <summary>
        /// PoolElement�𐶐��D
        /// ��������̏ꍇ�́C���ɐ�������Ă���PoolElement���Ԃ�܂��D
        /// </summary>
        /// <param name="position">�������̍��W</param>
        /// <param name="rotation">�������̉�]</param>
        /// <returns></returns>
        public T Generate(Vector3 position, Quaternion rotation)
        {
            var obj = Generate();

            obj.transform.position = position;
            obj.transform.rotation = rotation;

            return obj;
        }


        /// <summary>
        /// PoolElement�̏��������D
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
                    Debug.LogError("[ObjectPool] �ݒ肳��Ă���Prefab��ObjectPoolElement Component�����݂��܂���I");
#endif
                    break;
                }

                var castElement = element as T;
                if(castElement == null)
                {
                    Debug.LogError("[ObjectPool] �ݒ肳��Ă���Prefab��" + typeof(T) + "�^��ObjectPoolElement Component�����݂��܂���I");
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