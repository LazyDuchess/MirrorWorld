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
    }
}
