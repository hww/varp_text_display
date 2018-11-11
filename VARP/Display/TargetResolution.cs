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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Display
{
	/// <summary>
	/// The reason for this class is to make terminal window render same way for all cases
	/// of current view port.
	/// </summary>
	public struct TargetResolution 
	{
		public int Width;
		public int Height;
		
		[System.NonSerialized] public int Left;
		[System.NonSerialized] public int Right;
		[System.NonSerialized] public int Bottom;
		[System.NonSerialized] public int Top;

		public TargetResolution(int width, int height)
		{
			Width = width;
			Height = height;
			Left = 0;
			Right = 0;
			Bottom = 0;
			Top = 0;
		}

		/// <summary>
		/// Calculate vie-port coordinates for current Screen
		/// </summary>
		public void CalculateViewPortCoordinates()
		{
			CalculateViewPortCoordinates(Screen.width , Screen.height);
		}
		
		/// <summary>
		/// Calculate vie-port coordinates for given resolution
		/// </summary>
		public void CalculateViewPortCoordinates(int screenWidth, int screenHeight)
		{
			var viewPortAspect = (float)screenWidth / screenHeight;
			var targetAspect = (float)Width / Height;
			if (targetAspect > viewPortAspect)
			{
				Left = 0;
				Right = Width;
				var fixedHeight = Mathf.RoundToInt(Width / viewPortAspect);
				Bottom = -Mathf.RoundToInt((fixedHeight - Height) * 0.5f);
				Top = Bottom + fixedHeight;
			}
			else
			{
				Bottom = 0;
				Top = Height;
				var fixedWidth = Mathf.RoundToInt(Height * viewPortAspect);
				Left = -Mathf.RoundToInt((fixedWidth - Width) * 0.5f);
				Right = Left + fixedWidth;
			}
		}
	}

}
