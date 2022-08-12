using UnityEngine;

namespace ulma
{
    /// <summary>
    /// ObjectPool�ɂ���Đ��������Prefab�iPoolElement�j�̊Ǘ��N���X�D
    /// ��������Prefab�ɃA�^�b�`���Ă��������D
    /// </summary>
    public class ObjectPoolElement : MonoBehaviour
    {
        /// <summary>
        /// �L���ȏ�Ԃ��H
        /// </summary>
        public bool IsActive { get; private set; } = false;

        /// <summary>
        /// PoolElement��L��������D
        /// </summary>
        public void Activate()
        {
            IsActive = true;

            OnActivate();
        }


        /// <summary>
        /// PoolElement�𖳌�������D
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;

            OnInactivate();
        }


        /// <summary>
        /// �������D
        /// �������Ɉ�x�C�����I�ɌĂ΂�܂��D
        /// </summary>
        public void Initialize()
        {
            Inactivate();

            OnInitialize();
        }



        #region Inheritable Methods

        /// <summary>
        /// PoolElement�̗L�������ɌĂ΂�܂��D
        /// �p����ŏ�����ǉ��������Ƃ���override���Ă��������D
        /// </summary>
        protected virtual void OnActivate() { }

        /// <summary>
        /// PoolElement�̖��������ɌĂ΂�܂��D
        /// �p����ŏ�����ǉ��������Ƃ���override���Ă��������D
        /// </summary>
        protected virtual void OnInactivate() { }

        /// <summary>
        /// PoolElement�̏��������ɌĂ΂�܂��D
        /// �p����ŏ�����ǉ��������Ƃ���override���Ă��������D
        /// </summary>
        protected virtual void OnInitialize() { }

        #endregion
    }
}
