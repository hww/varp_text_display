// =============================================================================
// MIT License
// 
// Copyright (c) 2018 Valeriya Pudova (hww.github.io)
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

using UnityEngine;

namespace Code.Display
{
    public interface IDisplay
    {
        /// <summary>
        /// Set buffer dimensions 
        /// </summary>
        void SetBufferSize(int width, int height);
        
        /// <summary>
        /// Write character input field
        /// </summary>
        void Write ( char message );
        
        /// <summary>
        /// Write text to the input field
        /// </summary>
        void Write ( string message );

        /// <summary>
        /// Write text to display and add new line
        /// </summary>
        void WriteLine ( string message );
        
        /// <summary>
        /// Format text to display
        /// </summary>
        void WriteFormat(string format, params object[] args);
        
        /// <summary>
        /// Produce beep sound if it is defined
        /// </summary>
        void Beep ( );

        /// <summary>
        /// Clear terminal screen
        /// </summary>
        void Clear ( );

        /// <summary>
        /// Reset foreground color to default
        /// </summary>
        void ResetColor ( );

        /// <summary>
        /// Set foreground color
        /// </summary>
        void SetColor ( Color color );

        /// <summary>
        /// Set background color
        /// </summary>
        void SetBackgroundColor ( Color color );

        /// <summary>
        /// Set cursor position
        /// </summary>
        void SetCursor ( int x, int y );

        /// <summary>
        /// get buffer width
        /// </summary>
        int BufferWidth { get; }

        /// <summary>
        /// get buffer height
        /// </summary>
        int BufferHeight { get; }

        /// <summary>
        /// Sets the position of the console window relative to the screen buffer.
        /// </summary>
        void SetWindowPosition(int x, int y);

        /// <summary>
        /// Sets the height and width of the console window to the specified values.
        /// </summary>
        void SetWindowSize(int width, int height);

        /// <summary>
        /// Gets or sets the height of the console window area.
        /// </summary>
        int WindowLeft{ get; set; }
        
        /// <summary>
        /// Gets or sets the leftmost position of the console window area relative to the screen buffer.
        /// </summary>
        int WindowTop{ get; set; }

        /// <summary>
        /// Gets or sets the top position of the console window area relative to the screen buffer.
        /// </summary>
        int WindowWidth{ get; set; }

        /// <summary>
        /// Gets or sets the width of the console window.
        /// </summary>
        int WindowHeight { get; set; }

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination area.
        /// </summary>
        void MoveBufferArea(int sourceLeft,
            int sourceTop,
            int sourceWidth,
            int sourceHeight,
            int targetLeft,
            int targetTop);

        /// <summary>
        /// Copies a specified source area of the screen buffer to a specified destination area.
        /// </summary>
        void MoveBufferArea(int sourceLeft,
            int sourceTop,
            int sourceWidth,
            int sourceHeight,
            int targetLeft,
            int targetTop,
            char character,
            Color color);
    }

}
