using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityExtension {

    /// <summary>
    /// 简化Transform里面的LocalPosition的设置
    /// </summary>
    public static class LocalPositionSimplify {

        public static void SetLocalPosX(Transform transform,float x) {
            var localPos = transform.localPosition;
            localPos.x = x;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosY(Transform transform, float y) {
            var localPos = transform.localPosition;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosZ(Transform transform, float z) {
            var localPos = transform.localPosition;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosXY(Transform transform, float x, float y) {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosXZ(Transform transform, float x, float z) {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosYZ(Transform transform, float y, float z) {
            var localPos = transform.localPosition;
            localPos.y = y;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosXYZ(Transform transform, float x, float y, float z) {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.y = y;
            localPos.z = z;
            transform.localPosition = localPos;
        }
    }
}

