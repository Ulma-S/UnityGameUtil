using UnityEngine;

namespace ulma
{
    /// <summary>
    /// ObjectPool�̐ݒ�pScriptableObject�D
    /// </summary>
    [CreateAssetMenu(menuName = ("Ulma/ObjectPoolConfig"), fileName = ("ObjectPoolConfig"))]
    public class ObjectPoolConfig : ScriptableObject
    {
        [SerializeField, InspectorName("�ݒ�p�f�[�^")]
        private ObjectPoolData _Data;

        /// <summary>
        /// �ݒ�p�f�[�^
        /// </summary>
        public ObjectPoolData Data => _Data;
    }
}