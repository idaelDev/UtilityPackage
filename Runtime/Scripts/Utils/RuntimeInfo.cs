using UnityEditor;
using UnityEngine;

namespace IdaelDev.Utility
{
    public static class RuntimeInfo
    {
        public static bool IsEditor
        {
            get
            {
                #if UNITY_EDITOR
                return true;
                #else
            return false;
                #endif
            }
        }

        public static bool IsStandalone
        {
            get
            {
                #if UNITY_STANDALONE
                return true;
                #else
            return false;
                #endif
            }
        }

        public static RuntimePlatform RuntimeOS => Application.platform;

        public static string BuildTarget
        {
            get
            {
                #if UNITY_EDITOR
                return EditorUserBuildSettings.activeBuildTarget.ToString();
                #else
            return Application.platform.ToString();
                #endif
            }
        }

        public static bool IsDevelopmentBuild
        {
            get
            {
                #if UNITY_EDITOR
                return true;
                #else
            return Debug.isDebugBuild;
                #endif
            }
        }
    }
}
