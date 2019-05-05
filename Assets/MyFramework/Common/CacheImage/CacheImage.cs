
using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.Events;
using System.Security.Cryptography;//引用Md5转换功能
using System.Text;

public class CacheImage {

    private static CacheImage instences = null;
    private string path = //Application.persistentDataPath;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        Application.dataPath + "/StreamingAssets/Cache";
#elif UNITY_IPHONE || UNITY_ANDROID
        Application.persistentDataPath;         //persistentDataPath文件夹可读可写。
#else
        string.Empty;
#endif
    private string name = "{0}.png";

    private static UnityAction<Texture2D> cacheEvent;
    private static MonoBehaviour mono;

    public static CacheImage Cache(MonoBehaviour mb, UnityAction<Texture2D> callback)  //标准类的单例
    {
        cacheEvent = callback;
        mono = mb;
        if (instences == null) {
            instences = new CacheImage();
        }
        return instences;
    }

    public void DownLoad(string url, string identifyId) {
        if (mono != null) {
            mono.StartCoroutine(LoadTexture(url, identifyId));
        }
    }
   
    /// <summary>
    /// 判断是否本地有缓存
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private IEnumerator LoadTexture(string url, string identifyId) {
        if (!string.IsNullOrEmpty(url)) {
            if (!File.Exists(Path.Combine(path, string.Format(name, identifyId)))) {
                yield return LoadNetWorkTexture(url, identifyId);
            }
            else {
                yield return LoadLocalTexture(url, identifyId);
            }
        }
    }

    /// <summary>
    /// 本地已缓存
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private IEnumerator LoadLocalTexture(string url, string identifyId) {
        //已在本地缓存  
        Debug.Log("已在本地缓存");
        string filePath = "file:///" + Path.Combine(path, string.Format(name, identifyId));
        WWW www = new WWW(filePath);
        yield return www;
        cacheEvent.Invoke(www.texture);
    }

    /// <summary>
    /// 本地未缓存
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private IEnumerator LoadNetWorkTexture(string url, string identifyId) {
        WWW www = new WWW((new Uri(url)).AbsoluteUri);
        yield return www;
        Debug.Log("本地未缓存");
        if (!string.IsNullOrEmpty(www.error)) {
            Debug.Log("缓存失败");
            Debug.Log(string.Format("Failed to load image: {0}, {1}", url, www.error));
            yield break;
        }
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (!Directory.Exists(path)) {
            Directory.CreateDirectory(path);//创建新路径
        }
#endif
        Texture2D image = www.texture;
        //将图片保存至缓存路径  
        byte[] pngData = image.EncodeToPNG();
        File.WriteAllBytes(Path.Combine(path, string.Format(name, identifyId)), pngData);
        cacheEvent.Invoke(www.texture);
    }
   
    //计算字符串的Md5值 
    public static string GetMD5WithString(string input) {
        MD5 md5Hash = MD5.Create();
        // 将输入字符串转换为字节数组并计算哈希数据  
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        // 创建一个 Stringbuilder 来收集字节并创建字符串  
        StringBuilder str = new StringBuilder();
        // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串  
        for (int i = 0; i < data.Length; i++) {
            str.Append(data[i].ToString("x4"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
        }
        // 返回十六进制字符串  
        return str.ToString();
    }
}