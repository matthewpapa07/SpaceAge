using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace SpaceAge
{
    class UserInput
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);
        public static byte[] KeyArray = new byte[256];

        /// <summary>
        /// Must be called if you want the functions of this class not to return stale data
        /// </summary>
        static void RefreshStateArray()
        {
            GetKeyboardState(KeyArray);
        }

        static byte GetVirtualKeyCode(Key key)
        {
            int value = (int)key;
            return (byte)(value & 0xFF);
        }

        static byte GetVirtualKeyCode(char key)
        {
            if (key >= 'a' && key <= 'z')
            {
                return (byte)(key - 0x20);
            }
            if (key >= 'A' && key <= 'Z')
            {
                return (byte)key;
            }

            return (byte)key;
        }

        public static bool CheckKey(Key inKey)
        {
            RefreshStateArray();
            byte code = GetVirtualKeyCode(inKey);
            if (KeyArray[code] == 0)
            {
                return true;
            } 
            else 
            {
                return false;
            }
        }

        public static bool CheckKey(char inKey)
        {
            RefreshStateArray();
            byte code = GetVirtualKeyCode(inKey);
            if (KeyArray[code] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
