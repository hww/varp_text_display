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
    [CreateAssetMenu(menuName = "VARP/Display/Tango Theme")]
    public class TangoTheme : Xresources
    {
        /// <summary>
        /// The asset has Reset button it will call this method
        /// </summary>
        private void Reset()
        {
            // Tango color palette
            Background = ParseHtmlColor ("#2e343680");
            Foreground = ParseHtmlColor ( "#eeeeec" );
            CursorColor = ParseHtmlColor ( "#8ae23480" );
            // foreground color for underline
            SelectionColor = ParseHtmlColor ("#8ae23480");
            // black dark/light
            Colors[ 0 ] = ParseHtmlColor ( "#2e3436" );
            Colors[ 8 ] = ParseHtmlColor ( "#6e706b" );
            // red dark/light
            Colors[ 1 ] = ParseHtmlColor ( "#cc0000" );
            Colors[ 9 ] = ParseHtmlColor ( "#ef2929" );
            // green dark/light
            Colors[ 2 ] = ParseHtmlColor ( "#4e9a06" );
            Colors[ 10 ] = ParseHtmlColor ( "#8ae234" );
            // yellow dark/light
            Colors[ 3 ] = ParseHtmlColor ( "#edd400" );
            Colors[ 11 ] = ParseHtmlColor ( "#fce94f" );
            // blue dark/light
            Colors[ 4 ] = ParseHtmlColor ( "#3465a4" );
            Colors[ 12 ] = ParseHtmlColor ( "#729fcf" );
            // magenta dark/light
            Colors[ 5 ] = ParseHtmlColor ( "#92659a" );
            Colors[ 13 ] = ParseHtmlColor ( "#c19fbe" );
            // cyan dark/light
            Colors[ 6 ] = ParseHtmlColor ( "#07c7ca" );
            Colors[ 14 ] = ParseHtmlColor ( "#63e9e9" );
            // white dark/light
            Colors[ 7 ] = ParseHtmlColor ( "#d3d7cf" );
            Colors[ 15 ] = ParseHtmlColor ( "#eeeeec" );
        }
    }
}

