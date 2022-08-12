using UnityEngine;

namespace ulma 
{
    /// <summary>
    /// ObjectPoolを生成するstaticクラス．
    /// </summary>
    public static class ObjectPoolGenerator
    {
        /// <summary>
        /// ObjectPoolを生成．
        /// </summary>
        /// <typeparam name="T">PoolElementの型</typeparam>
        /// <param name="poolDataObject">設定用ScriptableObject</param>
        /// <param name="anchor">生成したPoolElementの親となるGameObject</param>
        /// <returns></returns>
        public static ObjectPool<T> CreatePool<T>(ObjectPoolConfig poolDataObject, GameObject anchor) where T : ObjectPoolElement
        {
            var pool = new ObjectPool<T>(poolDataObject.Data, anchor);

            return pool;
        }
    }
}