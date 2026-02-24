using UnityEngine;
using UnityEngine.InputSystem;

namespace IdaelDev.Utility
{
    public static class InputHelper
    {
        #region Keyboard

        public static bool GetKey(KeyCode key)
        {
#if ENABLE_INPUT_SYSTEM
            if (Keyboard.current == null)
                return false;

            if (System.Enum.TryParse(key.ToString(), out Key newKey))
                return Keyboard.current[newKey].isPressed;

            return false;

#elif ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetKey(key);
#else
        return false;
#endif
        }

        public static bool GetKeyDown(KeyCode key)
        {
#if ENABLE_INPUT_SYSTEM
            if (Keyboard.current == null)
                return false;

            if (System.Enum.TryParse(key.ToString(), out Key newKey))
                return Keyboard.current[newKey].wasPressedThisFrame;

            return false;

#elif ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetKeyDown(key);
#else
        return false;
#endif
        }

        public static bool GetKeyUp(KeyCode key)
        {
#if ENABLE_INPUT_SYSTEM
            if (Keyboard.current == null)
                return false;

            if (System.Enum.TryParse(key.ToString(), out Key newKey))
                return Keyboard.current[newKey].wasReleasedThisFrame;

            return false;

#elif ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetKeyUp(key);
#else
        return false;
#endif
        }

        #endregion


        #region Mouse

        public static Vector2 MousePosition
        {
            get
            {
#if ENABLE_INPUT_SYSTEM
                return Mouse.current != null
                    ? Mouse.current.position.ReadValue()
                    : Vector2.zero;

#elif ENABLE_LEGACY_INPUT_MANAGER
            return Input.mousePosition;
#else
            return Vector2.zero;
#endif
            }
        }

        public static bool GetMouseButton(int button)
        {
#if ENABLE_INPUT_SYSTEM
            if (Mouse.current == null)
                return false;

            return button switch
            {
                0 => Mouse.current.leftButton.isPressed,
                1 => Mouse.current.rightButton.isPressed,
                2 => Mouse.current.middleButton.isPressed,
                _ => false
            };

#elif ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetMouseButton(button);
#else
            return false;
#endif
        }

        public static bool GetMouseButtonDown(int button)
        {
#if ENABLE_INPUT_SYSTEM
            if (Mouse.current == null)
                return false;

            return button switch
            {
                0 => Mouse.current.leftButton.wasPressedThisFrame,
                1 => Mouse.current.rightButton.wasPressedThisFrame,
                2 => Mouse.current.middleButton.wasPressedThisFrame,
                _ => false
            };

#elif ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetMouseButtonDown(button);
#else
            return false;
#endif
        }

        #endregion


        #region Touch

        public static bool HasTouch()
        {
#if ENABLE_INPUT_SYSTEM
            return Touchscreen.current != null &&
                   Touchscreen.current.primaryTouch.press.isPressed;

#elif ENABLE_LEGACY_INPUT_MANAGER
            return Input.touchCount > 0;
#else
            return false;
#endif
        }

        public static Vector2 GetTouchPosition()
        {
#if ENABLE_INPUT_SYSTEM
            if (Touchscreen.current != null)
                return Touchscreen.current.primaryTouch.position.ReadValue();

            return Vector2.zero;

#elif ENABLE_LEGACY_INPUT_MANAGER
            return Input.touchCount > 0
                ? Input.GetTouch(0).position
                : Vector2.zero;
#else
            return Vector2.zero;
#endif
        }

        #endregion


        #region Pointer Unified

        public static Vector2 PointerPosition
        {
            get
            {
                if (HasTouch())
                    return GetTouchPosition();

                return MousePosition;
            }
        }

        public static bool PointerDown()
        {
#if ENABLE_INPUT_SYSTEM
            return
                (Mouse.current?.leftButton.wasPressedThisFrame == true) ||
                (Touchscreen.current?.primaryTouch.press.wasPressedThisFrame == true);

#elif ENABLE_LEGACY_INPUT_MANAGER
            return Input.GetMouseButtonDown(0) || Input.touchCount > 0;
#else
            return false;
#endif
        }

        #endregion
    }
}
