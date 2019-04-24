using System;
using System.Collections.Generic;
using System.Text;

namespace MyFramework {
    public class SkillDebug
    {
        public static bool Enable = true;

        static public void Log(object message) {
            Log(message, null);
        }
        static public void Log(object message, UnityEngine.Object context) {
            if (Enable) {
                Debug.Log("<color=green>[SKILL]</color>---" + message, context);
            }
        }
        static public void LogWarning(object message) {
            LogWarning(message, null);
        }
        static public void LogWarning(object message, UnityEngine.Object context) {
            if (Enable) {
                Debug.LogWarning("<color=blue>[SKILL]</color>---" + message, context);
            }
        }
        static public void LogError(object message) {
            LogError(message, null);
        }
        static public void LogError(object message, UnityEngine.Object context) {
            if (Enable) {
                Debug.LogError("<color=red>[SKILL]</color>---" + message, context);
            }
        }

    }
}