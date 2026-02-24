using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace IdaelDev.Utility
{
    public static class UIHelper
    {
        private static PointerEventData _eventDataCurrentPosition;
        private static List<RaycastResult> _raycastResults;

        public static bool IsOverUI()
        {
            _eventDataCurrentPosition = new PointerEventData(EventSystem.current)
            {
                position = InputHelper.MousePosition
            };
            _raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_eventDataCurrentPosition, _raycastResults);
            return _raycastResults.Count > 0;
        }

    }
}
