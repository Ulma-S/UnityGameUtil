using UnityEngine;

namespace ulma
{
    /// <summary>
    /// ObjectPoolの設定用ScriptableObject．
    /// </summary>
    [CreateAssetMenu(menuName = ("Ulma/ObjectPoolConfig"), fileName = ("ObjectPoolConfig"))]
    public class ObjectPoolConfig : ScriptableObject
    {
        [SerializeField, InspectorName("設定用データ")]
        private ObjectPoolData _Data;

        /// <summary>
        /// 設定用データ
        /// </summary>
        public ObjectPoolData Data => _Data;
    }
}