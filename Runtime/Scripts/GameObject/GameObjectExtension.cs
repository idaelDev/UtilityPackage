using UnityEngine;

namespace IdaelDev.Utility
{
    public static class GameObjectExtension
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (!component)
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }

        public static T OrNull<T>(this T obj) where T : Object => obj ? obj : null;

    }
}
