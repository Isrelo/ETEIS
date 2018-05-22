using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows;

namespace DragAndDrop
{
    public class Utilites
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Win32Point pos);

        /// <summary>
        /// Returns the position of the mouse cursor in screen coordinates
        /// </summary>
        /// <returns></returns>
        public static Point Win32GetCursorPos()
        {
            Win32Point position = new Win32Point();
            GetCursorPos(ref position);
            return new Point((double)position.X, (double)position.Y);
        }
    }
}
