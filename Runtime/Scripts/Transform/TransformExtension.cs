using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace IdaelDev.Utility
{
    public static class TransformExtension
    {

        public static void PerformActionOnChildren(this Transform transform, Action<Transform> action)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                action(transform.GetChild(i));
            }
        }

        public static void DestroyChildren(this Transform transform)
        {
            transform.PerformActionOnChildren(child => Object.Destroy(child.gameObject));
        }

        public static void EnableChildren(this Transform transform)
        {
            transform.PerformActionOnChildren(child => child.gameObject.SetActive(true));
        }

        public static void DisableChildren(this Transform transform)
        {
            transform.PerformActionOnChildren(child => child.gameObject.SetActive(false));
        }

        public static IEnumerable<Transform> GetAllChildren(this Transform transform)
        {
            return transform.Cast<Transform>();
        }



    }
}
