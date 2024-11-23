using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MirrorWorld
{
    public class CameraMirrorer : MonoBehaviour
    {
        private Material _material;

        private void Awake()
        {
            _material = Plugin.Instance.MirrorMaterial;
        }

        private void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, _material);
        }

        public static void AddToCamera(Camera camera)
        {
            var mirrorer = camera.GetComponent<CameraMirrorer>();
            if (mirrorer != null) return;
            camera.gameObject.AddComponent<CameraMirrorer>();
            return;
        }

        void OnAudioFilterRead(float[] data, int channels)
        {
            if (channels == 2)
            {
                for (int i = 0; i < data.Length; i += 2)
                {
                    float temp = data[i];
                    data[i] = data[i + 1];
                    data[i + 1] = temp;
                }
            }
        }
    }
}
