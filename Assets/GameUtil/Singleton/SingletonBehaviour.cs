using UnityEngine;

namespace ulma
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _Instance;
        public static T Instance
        {
            get 
            {
                if(_Instance == null)
                {
                    _Instance = FindObjectOfType<T>();

                    if (_Instance == null)
                    {
                        Debug.LogError("[SingletonBehaviour] " + typeof(T) + "�^�̃C���X�^���X�͑��݂��Ȃ�������������Ă��܂���I");
                        return null;
                    }
                }

                return _Instance;
            }
        }

        private void Awake()
        {
            if (_Instance == null)
            {
                _Instance = this as T;

                InheritedAwake();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void InheritedAwake() { }
    }
}