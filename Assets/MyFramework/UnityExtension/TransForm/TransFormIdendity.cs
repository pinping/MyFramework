using UnityEngine;


namespace UnityExtension {

    /// <summary>
    /// 重置 Transform 的位置.
    /// </summary>
    public static class TransFormIdendity {

        public static void Idendity(Transform transform) {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}
