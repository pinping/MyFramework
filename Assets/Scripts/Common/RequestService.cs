using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace MyFramework {
    [Serializable]
    public class RequestService : MonoBehaviour {

        private static RequestService instance;
        public static RequestService Instance {
            get {
                if (instance == null) {
                    instance = new GameObject("RequestService").AddComponent<RequestService>();
                    DontDestroyOnLoad(instance);
                }
                return instance;
            }
        }

        private void Awake() {

        }

        /********************** 请求模块 **************************************/
        public event Action<string> reqFailed = null;
        public event Action<Dictionary<string, string>> reqComplete = null;

        // 注册请求失败回调
        public void RegisteFailedBack(Action<string> back) {
            if (back != null)
                reqFailed = back;
            Debug.Log("RegisteFailedBack back +" + back);
        }

        // 注册请求成功回调
        public void RegisteCompleteBack(Action<Dictionary<string, string>> back) {
            if (back != null)
                reqComplete = back;
            Debug.Log("RegisteCompleteBack back +" + back);
        }

        /// <summary>
        /// Sets the headers data.(返回请求头信息)
        /// </summary>
        /// <returns>The headers data.</returns>
        /// <param name="version">Version.</param>
        /// <param name="encrypt">Encrypt.</param>
        /// <param name="token">Token.</param>
        /// <param name="ports">Ports.</param>
        private Dictionary<string, string> SetHeadersData(string version, string encrypt, string token, string ports) {

            string timeStr = GetTimeStamp().ToString();

            Dictionary<string, string> headers = new Dictionary<string, string>
            {
            { "version", version },
            { "timestamp", timeStr },
            { "encrypt", encrypt },
            { "token", token },
            { "ports", ports },
            { "os", "unity3D" }
        };
            return headers;
        }

        // 获取当前时间
        private long GetTimeStamp(bool bflag = true) {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            long ret;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds);
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds);
            return ret;
        }

        private IEnumerator PostUrl(string url, string type, Dictionary<string, string> dic, string postData) {

            Debug.Log("url" + url);
            Debug.Log("type" + type);
            Debug.Log("dic" + dic);
            Debug.Log("postData" + postData);

            using (UnityWebRequest www = new UnityWebRequest(url, "POST")) {
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                www.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
                www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

                foreach (var item in dic) {
                    www.SetRequestHeader(item.Key, item.Value);
                }

                yield return www.SendWebRequest();

                Debug.Log("www.error-------:" + www.error);
                Debug.Log("www.responseCode-------:" + www.responseCode);
                Debug.Log("www.downloadHandler.text-------:" + www.downloadHandler.text);

                if (www.isNetworkError) {
                    reqFailed.Invoke(www.downloadHandler.text);
                }
                else {
                    if (www.responseCode == 200) {
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        dict.Add("type", type);
                        dict.Add("data", www.downloadHandler.text);
                        reqComplete.Invoke(dict);
                    }
                    else {
                        reqFailed.Invoke(www.downloadHandler.text);
                    }
                }
            }
        }
    }
}
