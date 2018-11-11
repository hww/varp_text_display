// =============================================================================
// MIT License
// 
// Copyright (c) [2018] [Valeriya Pudova] https://github.com/hww
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// =============================================================================

using System;
using UnityEngine;

namespace Code.Display
{
    /// <summary>
    /// Represent the cursor behavior for terminal emulator 
    /// </summary>
    public class DisplayCursor
    {
        const int TabSize = 8;
        private int x;                  //< position x
        private int y;                  //< position y
        private int top;                //< window top
        private int left;               //< window left
        private int bottom;             //< window bottom
        private int right;              //< window right
        private int width;              //< window width
        private int height;             //< window height
        private int bufferWidth;        //< buffer
        private int bufferHeight;       //< buffer
        private readonly TextDisplay display;    //< required for scrolling
        /// <summary>
        /// Construct the cursor for given terminal
        /// </summary>
        public DisplayCursor ( TextDisplay display )
        {
            this.display = display;
        }
        /// <summary>
        /// Set window geometry
        /// </summary>
        private void OnUpdateGeometry ( )
        {
            Debug.Assert ( left >= 0 && left < bufferWidth, "left: " + left.ToString ( ) );
            Debug.Assert ( top >= 0 && top < bufferHeight, "top: " + top.ToString ( ) );
            Debug.Assert ( width > 0 && width <= ( bufferWidth - left ), "width: " + width.ToString ( ) );
            Debug.Assert ( height > 0 && height <= ( bufferHeight - top ), "height: " + height.ToString() );
            this.right = left + width - 1;
            this.bottom = top + height - 1;
            this.x = left;
            this.y = top;
        }
        /// <summary>
        /// Set buffer size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetBufferSize ( int width, int height )
        {
            this.bufferWidth = width;
            this.bufferHeight = height;
            this.left = 0;
            this.top = 0;
            this.width = width;
            this.height = height;
            OnUpdateGeometry ( );
        }
        /// <summary>
        /// Sets the position of the console window relative to the screen buffer.
        /// </summary>
        public void SetWindowPosition ( int left, int top )
        {
            this.left = left;
            this.top = top;
            OnUpdateGeometry ( );
        }
        /// <summary>
        /// Sets the height and width of the console window to the specified values.
        /// </summary>
        public void SetWindowSize ( int width, int height )
        {
            this.width = width;
            this.height = height;
            OnUpdateGeometry ( );
        }
        /// <summary>
        /// Gets or sets the height of the console window area.
        /// </summary>
        public int WindowLeft { get { return left; } set { left = value; OnUpdateGeometry ( ); } }
        /// <summary>
        /// Gets or sets the leftmost position of the console window area relative to the screen buffer.
        /// </summary>
        public int WindowTop { get { return top; } set { top = value; OnUpdateGeometry ( ); } }
        /// <summary>
        /// Gets or sets the top position of the console window area relative to the screen buffer.
        /// </summary>
        public int WindowWidth { get { return width; } set { width = value; OnUpdateGeometry ( ); } }
        /// <summary>
        /// Gets or sets the width of the console window.
        /// </summary>
        public int WindowHeight { get { return height; } set { height = value; OnUpdateGeometry ( ); } }
        /// <summary>
        /// Gets the right position of window area
        /// </summary>
        public int WindowRight { get { return right; } } 
        /// <summary>
        /// Gets the bottom position of window area
        /// </summary>
        public int WindowBottom { get { return bottom; } } 
        /// <summary>
        /// Set X,Y position inside given window 
        /// </summary>
        public void SetPosition ( int x, int y )
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Get/Set X position inside given window 
        /// </summary>
        public int X
        {
            get { return x; }
            set {
                Debug.Assert ( x >= 0 && x < bufferWidth );
                x = value;
            }
        }
        /// <summary>
        /// Get/Set Y position inside given window 
        /// </summary>
        public int Y
        {
            get { return y; }
            set {
                Debug.Assert ( y >= 0 && y < bufferHeight );
                y = value;
            }
        }
        /// <summary>
        /// Increment decrement X position of cursor and update Y position  or scroll terminal if it needed
        /// </summary>
        public void AddX ( int increment )
        {
            var value = x + increment;
            if ( value < left )
            {
                x = right;
                AddY ( -1 );
            }
            else if (value > right )
            {
                x = left;
                AddY ( 1 );
            }
            else
            {
                x = value;
            }
        }
        /// <summary>
        /// Increment decrement Y position of cursor and scroll terminal if it needed
        /// </summary>
        public void AddY ( int increment )
        {
            var value = y + increment;
            if ( value < top )
            {
                x = top;
                display.MoveBufferArea ( WindowLeft, WindowTop, WindowWidth, WindowHeight - 1, WindowLeft, WindowTop + 1 );
            }
            else if ( value > bottom)
            {
                y = bottom;
                display.MoveBufferArea ( WindowLeft, WindowTop + 1, WindowWidth, WindowHeight - 1, WindowLeft, WindowTop );
            }
            else
            {
                y = value;
            }
        }
        /// <summary>
        /// Move to next line 
        /// </summary>
        public void NewLine ( )
        {
            x = left;
            AddY ( 1 );
        }
        /// <summary>
        ///  Return position before next tab
        /// </summary>
        public int GetCharsToEndOfTabColumn( )
        {
            if (x < left)
            {
                x = left;
                return 0;
            }

            if (x > right)
            {
                NewLine();
                return 0;
            }
            var endOfColumn = Clamp(((x / TabSize) + 1) * TabSize - 1, left, right);
            return endOfColumn - x;
        }
        /// <summary>
        /// Get next tab position
        /// </summary>
        public int GetNextTab()
        {
            var tab = ((x / TabSize) + 1) * TabSize;
            return tab < left ? left : (tab <= right ? tab : left); 
        }
        private int Clamp ( int value, int min, int max )
        {
            return value < min ?  min : ( value > max ?  max :  value);
        }
    }
}

