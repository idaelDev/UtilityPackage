using UnityEngine;

namespace IdaelDev.Utility
{
    public static class CameraHelper
    {
        private static Camera _camera;

        public static Camera Camera
        {
            get
            {
                if (_camera == null) _camera = Camera.main;
                return _camera;
            }
        }
    }
}
