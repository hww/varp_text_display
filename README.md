# VARP Text Display

Debugging tool for Unity 3D. Render text display as a screen overlay. Difference between this tool and using Text widget is: this tool does not produce garbage any time when you need to change single character. To work w/o garbage it uses immediate draw. Other words it draw characters with `GL.Begin(GL.QUADS)`.

Every character on screen has color and additional `inverse` flag.

## Folders & Files

Copy VARP folder inside 

_/VARP/Display_          Source code of this asset
_/VARP/Display/Demo_     Source code of demo scene

_IDisplay.cs_            API of this asset
_TextDisplay.cs_         Text display source code.
_TargetResolution.cs_    Target resolution settings
_DisplayCursor.cs_       Cursor movement and window regions.
_Xresources.cs_          Color theme (ScriptableObject)
_TangoTheme.cs_          Tango color theme

## API

To instantiate display use `new` operator.

```C#
    TextDisplay textDisplay;
    targetResolution = new TargetResolution(1920, 1080);
    TargetResolution targetResolution;
    textDisplay = new TextDisplay ( 64, 24 );
```
To print text use `Write`, `WriteLine`, `WriteFormat` method. Keep in mind that `WriteFormat` will produce garbage anyway.

```C#
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

To render display use method `Render` with two arguments: position and target resolution.

```C#
    textDisplay.Render ( new Vector3 (), targetResolution);
```