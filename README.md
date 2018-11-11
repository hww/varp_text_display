# VARP Text Display

This asset is debugging tool for Unity 3D. It render text as a screen overlay with usubg immediate draw. Other words it draw characters with GL.QUADS and as result it does not produce garbage when update text.

The text dispay has a buffer for characters and every character has a color value and additional inverse flag. Last one allow to render negative version of glyph. Just change character code in the buffer will character on screen.

## Folders & Files

Table 1. The description for each folder. 

| Folder                           | Info                      | 
|----------------------------------|---------------------------|
| _/VARP/Display_          | Source code of this asset. |
| _/VARP/Display/Demo_     | Demo scene. |
| _/Resources/VARP/DebugDraw_ |	Font, shaders and materials for this assset. |

Table 2. The description for each file. 

| File                 | Info                                  |
|----------------------|---------------------------------------|
| _IDisplay.cs_        | Public API of this asset. |
| _TextDisplay.cs_     | Text display source code, implementation of _IDisplay_. |
| _TargetResolution.cs_| Target resolution settings. |
| _DisplayCursor.cs_   | Cursor movement and screen's regions (windows). |
| _Xresources.cs_      | Color theme (ScriptableObject). |
| _TangoTheme.cs_      | Tango color theme (ScriptableObject). |
| _DisplayDemoCameraC.cs_ |	The componet for game came with example of using this asset. |

## Usage

- Copy VARP from Resources folder to Resources folder of your project.
- Copy VARP folder inside Plugins folder.
- Add demo component DisplayDemoCameraC to your camera. Run scene and play with component's values.

## Introduction to API

To instantiate display use `new` operator.

```C#
    var targetResolution = new TargetResolution(1920, 1080);
    var textDisplay = new TextDisplay ( 64, 24 );
```

Mehtod above will create display with default Tango color theme. To alternate colors use your colorTheme as third argument.

```C#
    var targetResolution = new TargetResolution(1920, 1080);
    var textDisplay = new TextDisplay ( 64, 24, customColorTheme );
```

To print text use `Write`, `WriteLine`, `WriteFormat` method. Keep in mind that `WriteFormat` will produce garbage anyway.

```C#
    textDisplay.Write('C');
    textDisplay.Write("Hello World!");
    textDisplay.WriteLine("Hello World!");
    textDisplay.WriteFormat("\"{0}\"", "Hello World!");
```
For other methods read content of _IDisplay.cs_ file.

There are various of methods for alternating visibility.
 
```C#
    textDisplay.IsVisible = true;            // Main visibility
    textDisplay.IsTextVisible = true;        // Text visibility
    textDisplay.IsBackgroundVisible = true;  // Background visibility
    textDisplay.IsCursorVisible = true;      // Cursor visibility
```

To render display use method _Render_ with two arguments: position and target resolution.

```C#
    textDisplay.Render ( new Vector3 (), targetResolution);
```

## ToDo

Add support of Escape sequences. 
