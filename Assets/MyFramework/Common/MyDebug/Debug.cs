using System;
using UnityEngine;

namespace MyFramework {
    public class Debug
    {
        static public bool Enable = true;
        static public void Log(object message) {
            Log(message, null);
        }
        static public void Log(object message, UnityEngine.Object context) {
            if (Enable) {
                UnityEngine.Debug.Log(message, context);
            }
        }
        static public void LogWarning(object message) {
            LogWarning(message, null);
        }
        static public void LogWarning(object message, UnityEngine.Object context) {
            if (Enable) {
                UnityEngine.Debug.LogWarning(message, context);
            }
        }
        static public void LogError(object message) {
            LogError(message, null);
        }
        static public void LogError(object message, UnityEngine.Object context) {
            if (Enable) {
                UnityEngine.Debug.LogError(message, context);
            }
        }
        public static void LogException(Exception exception) {
            UnityEngine.Debug.LogException(exception);
        }
        public static void LogException(Exception exception, UnityEngine.Object context) {
            UnityEngine.Debug.LogException(exception, context);
        }
        public static void DrawLine(Vector3 start, Vector3 end) {
            UnityEngine.Debug.DrawLine(start, end);
        }
        public static void DrawLine(Vector3 start, Vector3 end, Color color) {
            UnityEngine.Debug.DrawLine(start, end, color);
        }
        public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration) {
            UnityEngine.Debug.DrawLine(start, end, color, duration);
        }
        public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest) {
            UnityEngine.Debug.DrawLine(start, end, color, duration, depthTest);
        }
        public static void DrawRay(Vector3 start, Vector3 dir) {
            UnityEngine.Debug.DrawRay(start, dir);
        }
        public static void DrawRay(Vector3 start, Vector3 dir, Color color) {
            UnityEngine.Debug.DrawRay(start, dir, color);
        }
        public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration) {
            UnityEngine.Debug.DrawRay(start, dir, color, duration);
        }
        public static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest) {
            UnityEngine.Debug.DrawRay(start, dir, color, duration, depthTest);
        }
        public static void Break() {
            UnityEngine.Debug.Break();
        }
        public static void ClearDeveloperConsole() {
            UnityEngine.Debug.ClearDeveloperConsole();
        }
        public static void DebugBreak() {
            UnityEngine.Debug.DebugBreak();
        }
    }
}