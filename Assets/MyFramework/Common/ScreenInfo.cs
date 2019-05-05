using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyFramework {
    public class ScreenInfo : MonoBehaviour {

        /// <summary>
        /// 获取横屏的屏幕的宽高比
        /// </summary>
        /// <returns>宽高比</returns>
        public static float GetAspectRatio() {
            var isLandscape = Screen.width > Screen.height;
            return isLandscape ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;
        }

        /// <summary>
        /// 获取屏幕与目标宽的宽比
        /// </summary>
        /// <returns>宽宽比.</returns>
        /// <param name="width">目标宽.</param>
        public static float GetAspectRatio(float width) {
            return width / Screen.width;
        }

        public static bool IsiPadResolution() {
            return InAspectRange(4f / 3.0f);
        }

        public static bool IsPhoneResolution() {
            return InAspectRange(16f / 9.0f);
        }

        public static bool InAspectRange(float dstAspectRatio) {
            var aspect = GetAspectRatio();
            return aspect > (dstAspectRatio - 0.05) && aspect < (dstAspectRatio + 0.05);
        }
    }
}
