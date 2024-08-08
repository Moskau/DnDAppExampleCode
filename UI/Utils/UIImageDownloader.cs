using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace DnD.UI
{
    public class UIImageDownloader : MonoBehaviour
    {
        [SerializeField]
        private Image m_image = null;
        [SerializeField]
        private bool m_cacheImage = false;

        public Image Image { get { return m_image; } }

        public IEnumerator LoadImageFromURL(string url)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
                m_image.sprite = sprite;
                if (m_cacheImage)
                {
                    CacheImageToDisk();
                }

            }
        }

        private void CacheImageToDisk()
        {
            byte[] textureBytes = m_image.sprite.texture.EncodeToPNG();
            File.WriteAllBytes(Application.persistentDataPath + "/DnDContentImages", textureBytes);
            Debug.Log("Image Cached At: " + "/DnDContentImages");
        }
    }
}
