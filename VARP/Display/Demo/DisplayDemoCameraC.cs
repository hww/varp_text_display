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
using UnityEngine;

namespace Code.Display.Demo
{
    public class DisplayDemoCameraC : MonoBehaviour 
    {
        public bool RenderInEditor;
        public bool RenderInPostRender;
        public bool RenderInEndOfFrame;
        public bool IsVisible;
        public bool IsBackgroundVisible;
        public bool IsCursorVisible;
        public bool IsTextVisible;
        public Vector3 TextScale = Vector3.one;
        
        private TextDisplay textDisplay;
        private TargetResolution targetResolution;
        
        private void OnEnable ( )
        {
            targetResolution = new TargetResolution(1920, 1080 );
            textDisplay = new TextDisplay ( 64, 24 );
            textDisplay.WriteLine("Text Display");
            textDisplay.Write("Print ");
            textDisplay.SetColor(Color.red);
            textDisplay.Write("Red");
            textDisplay.SetColor(Color.white);
            textDisplay.WriteLine(" Color");
            textDisplay.Write("Print ");
            textDisplay.IsNegative = true;
            textDisplay.Write("Selected");
            textDisplay.IsNegative = false;
            textDisplay.WriteLine(" Text");
        }
        
        private void OnDisable()
        {
            textDisplay = null;
        }
        
        void OnGUI ( )
        {
            Event e = Event.current;
            if ( e.isKey )
                textDisplay.Write ( ((char)(int)e.keyCode).ToString() );
        }

        private void Update ( )
        {
            textDisplay.IsTextVisible = IsTextVisible;
            textDisplay.IsVisible = IsVisible;
            textDisplay.IsBackgroundVisible = IsBackgroundVisible;
            textDisplay.IsCursorVisible = IsCursorVisible;
        }

        /// <summary>
        /// To render objects in the GameView 
        /// </summary>
        /// <returns></returns>
        IEnumerator OnPostRender ( )
        {
            if ( RenderInPostRender )
                Render();
            yield return new WaitForEndOfFrame ( );
            if ( RenderInEndOfFrame )
                Render();
        }

        void OnRenderObject ( )
        {
            if (RenderInEditor && Camera.current != null && Camera.current.name == "SceneCamera")
                Render();
        }

        private void Render()
        {
            textDisplay.Render ( new Vector3 ( 0, 0 ), targetResolution);
        }
    }
}

