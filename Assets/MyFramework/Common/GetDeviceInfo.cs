using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDeviceInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnGUI() {
        GUILayout.Space(10);
        GUILayout.Label("设备的详细信息");
        GUILayout.Space(8);
        GUILayout.Label("设备模型:" + SystemInfo.deviceModel);
        GUILayout.Space(8);
        GUILayout.Label("设备名称:" + SystemInfo.deviceName);
        GUILayout.Space(8);
        GUILayout.Label("设备类型:" + SystemInfo.deviceType.ToString());
        GUILayout.Space(8);
        GUILayout.Label("设备唯一标识符:" + SystemInfo.deviceUniqueIdentifier);
        GUILayout.Space(8);
        GUILayout.Label("是否支持纹理复制:" + SystemInfo.copyTextureSupport.ToString());
        GUILayout.Label("显卡ID:" + SystemInfo.graphicsDeviceID.ToString());
        GUILayout.Label("显卡名称:" + SystemInfo.graphicsDeviceName);
        GUILayout.Label("显卡类型:" + SystemInfo.graphicsDeviceType.ToString());
        GUILayout.Label("显卡供应商:" + SystemInfo.graphicsDeviceVendor);
        GUILayout.Label("显卡供应商ID:" + SystemInfo.graphicsDeviceVendorID.ToString());
        GUILayout.Label("显卡版本号:" + SystemInfo.graphicsDeviceVersion);
        GUILayout.Label("显存大小（单位：MB）:" + SystemInfo.graphicsMemorySize);
        GUILayout.Label("显卡是否支持多线程渲染:" + SystemInfo.graphicsMultiThreaded.ToString());
        GUILayout.Label("支持的渲染目标数量:" + SystemInfo.supportedRenderTargetCount.ToString());
        GUILayout.Label("系统内存大小(单位：MB):" + SystemInfo.systemMemorySize.ToString());
        GUILayout.Label("操作系统:" + SystemInfo.operatingSystem);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
