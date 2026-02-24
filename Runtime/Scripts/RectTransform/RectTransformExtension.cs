using System;
using UnityEngine;

namespace IdaelDev.Utility
{
    public static class RectTransformExtension
    {
        public static Vector2 GetWorldPosition(this RectTransform rectTransform)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, rectTransform.position, CameraHelper.Camera, out var result);
            return result;
        }

        public static Vector2 GetWorldPosition(this RectTransform rectTransform, Camera camera)
        {
            if(camera == null) throw new ArgumentException("Camera argument could not be null.");
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, rectTransform.position, camera, out var result);
            return result;
        }
    }
}
