using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    public RawImage image;
    void Start() {
        string url = "http://www.shijunzh.com/wp-content/uploads/2017/06/cropped-icon.png";
        string name = CacheImage.GetMD5WithString(url);

        CacheImage.Cache(this, CacheEvent).DownLoad(url, name);
    }

    void CacheEvent(Texture2D t) {
        image.texture = t;
    }
}
