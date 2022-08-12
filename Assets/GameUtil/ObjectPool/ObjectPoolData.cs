using UnityEngine;

namespace ulma
{
    /// <summary>
    /// ObjectPoolの設定データ．
    /// </summary>
    [System.Serializable]
    public class ObjectPoolData
    {
        [SerializeField, InspectorName("生成するPrefab")]
        private GameObject _Prefab;

        /// <summary>
        /// 生成するPrefab
        /// </summary>
        public GameObject Prefab => _Prefab;
        
        [SerializeField, InspectorName("最大生成数")]
        private int _MaxCount = 10;
        
        /// <summary>
        /// 最大生成数
        /// </summary>
        public int MaxCount => _MaxCount;
    }
}