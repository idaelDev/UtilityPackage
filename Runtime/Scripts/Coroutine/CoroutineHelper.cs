using System.Collections.Generic;
using UnityEngine;

namespace IdaelDev.Utility
{
    public static class CoroutineHelper
    {
        private static readonly Dictionary<float, WaitForSeconds> _waitDictionary = new Dictionary<float, WaitForSeconds>();

        public static WaitForSeconds GetWaitForSeconds(float time)
        {
            if (_waitDictionary.TryGetValue(time, out var wait))
            {
                return wait;
            }

            _waitDictionary[time] = new WaitForSeconds(time);
            return _waitDictionary[time];
        }
    }
}
