using UnityEngine;

namespace ulma
{
    /// <summary>
    /// ObjectPoolによって生成されるPrefab（PoolElement）の管理クラス．
    /// 生成するPrefabにアタッチしてください．
    /// </summary>
    public class ObjectPoolElement : MonoBehaviour
    {
        /// <summary>
        /// 有効な状態か？
        /// </summary>
        public bool IsActive { get; private set; } = false;

        /// <summary>
        /// PoolElementを有効化する．
        /// </summary>
        public void Activate()
        {
            IsActive = true;

            OnActivate();
        }


        /// <summary>
        /// PoolElementを無効化する．
        /// </summary>
        public void Inactivate()
        {
            IsActive = false;

            OnInactivate();
        }


        /// <summary>
        /// 初期化．
        /// 生成時に一度，自動的に呼ばれます．
        /// </summary>
        public void Initialize()
        {
            Inactivate();

            OnInitialize();
        }



        #region Inheritable Methods

        /// <summary>
        /// PoolElementの有効化時に呼ばれます．
        /// 継承先で処理を追加したいときにoverrideしてください．
        /// </summary>
        protected virtual void OnActivate() { }

        /// <summary>
        /// PoolElementの無効化時に呼ばれます．
        /// 継承先で処理を追加したいときにoverrideしてください．
        /// </summary>
        protected virtual void OnInactivate() { }

        /// <summary>
        /// PoolElementの初期化時に呼ばれます．
        /// 継承先で処理を追加したいときにoverrideしてください．
        /// </summary>
        protected virtual void OnInitialize() { }

        #endregion
    }
}
