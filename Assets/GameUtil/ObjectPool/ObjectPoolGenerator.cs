using UnityEngine;

namespace ulma 
{
    /// <summary>
    /// ObjectPool�𐶐�����static�N���X�D
    /// </summary>
    public static class ObjectPoolGenerator
    {
        /// <summary>
        /// ObjectPool�𐶐��D
        /// </summary>
        /// <typeparam name="T">PoolElement�̌^</typeparam>
        /// <param name="poolDataObject">�ݒ�pScriptableObject</param>
        /// <param name="anchor">��������PoolElement�̐e�ƂȂ�GameObject</param>
        /// <returns></returns>
        public static ObjectPool<T> CreatePool<T>(ObjectPoolConfig poolDataObject, GameObject anchor) where T : ObjectPoolElement
        {
            var pool = new ObjectPool<T>(poolDataObject.Data, anchor);

            return pool;
        }
    }
}