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

