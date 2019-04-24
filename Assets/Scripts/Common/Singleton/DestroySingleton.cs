using UnityEngine;

namespace MyFramework {
    /// <summary>
    /// Destroy singleton.
    /// 切换场景会自动 Destroy 
    /// </summary>
    public abstract class DestroySingleton<T> where T : class, new() {

        protected static T _instance = null;

        public static T Instance {
            get {
                if (null == _instance) {
                    _instance = new T();
                }
                return _instance;
            }
        }

        protected DestroySingleton() {
            if (null != _instance) {
                Debug.LogError("This " + (typeof(T)).ToString() + "DestroySingleton Instance is not null !!!");
            }
            Init();
        }

        public virtual void Init() {

        }
    }
}