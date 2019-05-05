using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MyFramwork {

    public class ExportUnityPackage : MonoBehaviour {


        public static void CopyText(string text) {
            GUIUtility.systemCopyBuffer = text;
        }

        public static string GeneratePackageName() {
            return "MyFramwork_" + DateTime.Now.ToString("yyyyMMdd_hh");
        }

        public static void OpneInFolder(string folderPath) {
            Application.OpenURL("file://" + folderPath);
        }

#if UNITY_EDITOR

        public static void ExportPackage(string assetPathName, string fileName) {
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        }

        [MenuItem("MyFramwork/导出 UnityPackage")]
        private static void MenuClicked01() {
            var assetPathName = "Assets/MyFramework";
            var fileName = "MyFramwork_" + DateTime.Now.ToString("yyyyMMdd_hh") + ".unitypackage";
            AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
        }

        [MenuItem("MyFramwork/导出 UnityPackage 并打开文件夹 %e")]
        private static void MenuClicked02() {
            EditorApplication.ExecuteMenuItem("MyFramwork/导出 UnityPackage");
            Application.OpenURL("file://" + Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}