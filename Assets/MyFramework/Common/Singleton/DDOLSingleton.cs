using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework {
    /// <summary>
    /// 基类实现了单例方法，并且不随着场景的切换而销毁
    /// </summary>
    public abstract class DDOLSingleton<T> : MonoBehaviour where T : DDOLSingleton<T>
    {
        protected static T _instance = null;

        public static T Instance
        {
            get {
                // 如果 _instance 为空
                if (null == _instance) {
                    // 寻找不销毁的组件DDOL (可以手动创建,也可以通过下面的脚本实现)
                    GameObject go = GameObject.Find("DDOL");

                    // 如果DDOL组件为空
                    if (null == go) {
                        // 创建DDOL组件
                        go = new GameObject("DDOL");

                        // 设置为不可销毁
                        DontDestroyOnLoad(go);
                    }
                    // 在DDOL组件上得到组件
                    _instance = go.GetComponent<T>();

                    // 如果是空,测说明DDOL组件没有添加T组件
                    if (null == _instance) {
                        // 给DDOL组件添加T组件,并且赋值给 _instance
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
    }
}