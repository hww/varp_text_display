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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Display
{

    public class DisplayCamera : MonoBehaviour
    {
        public int width = 1920;
        public int height = 1080;
        public int columns = 64;
        public int lines = 64;
        public Vector3 position;
        public bool isBackgroundVisible;
        public bool isCursorVisible;
        public bool isTextVisible;

        private TextDisplay textDisplay;
        private TargetResolution targetResolution;
        private bool isVisible;
        
        void Start()
        {
            targetResolution = new TargetResolution(width, height);
            textDisplay = new TextDisplay(columns, lines);
            textDisplay.WriteLine("Display " + name);
        }

        /// <summary>
        /// To render objects in the GameView 
        /// </summary>
        /// <returns></returns>
        void OnPostRender()
        {
            if (isVisible)
                textDisplay.Render(position, targetResolution);
        }

        public void SetVisible(bool state)
        {
            isVisible = state;
            if (targetResolution.Width != width || targetResolution.Height != height)
                targetResolution = new TargetResolution(width, height);
            if (textDisplay.BufferWidth != columns || textDisplay.BufferWidth != lines)
                textDisplay = new TextDisplay(columns, lines);
            textDisplay.IsVisible = isVisible;
            textDisplay.IsTextVisible = isTextVisible;
            textDisplay.IsBackgroundVisible = isBackgroundVisible;
            textDisplay.IsCursorVisible = isCursorVisible;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
                SetVisible(!isVisible);
            
            //if (isVisible)
            //    textDisplay.Render(position, targetResolution);
        }
    }
}