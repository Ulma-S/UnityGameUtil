using UnityEngine;

namespace ulma
{
    /// <summary>
    /// ObjectPool�̐ݒ�f�[�^�D
    /// </summary>
    [System.Serializable]
    public class ObjectPoolData
    {
        [SerializeField, InspectorName("��������Prefab")]
        private GameObject _Prefab;

        /// <summary>
        /// ��������Prefab
        /// </summary>
        public GameObject Prefab => _Prefab;
        
        [SerializeField, InspectorName("�ő吶����")]
        private int _MaxCount = 10;
        
        /// <summary>
        /// �ő吶����
        /// </summary>
        public int MaxCount => _MaxCount;
    }
}