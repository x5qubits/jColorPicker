# J Color Picker
<link rel="shortcut icon" type="image/x-icon" href="Resources/jColorPickerLogo.ico">

![Build Status Travis-CI](https://img.shields.io/appveyor/ci/x5Qubits/jColorPicker?style=flat-square)

J Color Picker a multi-purpose color picker for web designers and programmers. It identifies and represents colors in various color code formats. Simply drag the eyedropper control to any location on the screen and release or place place your cursor on the color you want and then press ALT+S. The color code for the selected color will be automatically copied to the clipboard. See other features.

## Features
- Extensive range of color code formats:HEX, RGB, RGBA, HSB/HSV, HSL, and User Defined (Custom).
- List of palettes
- CSS-compatible colur codes.
- User-defined hotkeys.
- High-DPI awareness.
- Multi-display support.
- No installation required. Just Color Picker is a portable application and can be run directly from a USB stick.
- Copying the colour code to the clipboard with one mouse click or automatically.
- Optional stay-on-top behaviour.

## Resources
* [Download Bins](https://github.com/x5qubits/jColorPicker/releases/download/1/Release.zip)
* [Issue Tracker](https://github.com/x5qubits/jColorPicker/issues)

## Custom Color Code
Replace Map:
~~~~
@R = red
@G = green
@B = blue
@A = alpha
@H = hue
@S = saturation
@L = lightness
@DA=alpha (0.x)
~~~~

Example for color red:
~~~~
rgb(@R, @G, @B); will output rgb(255, 0, 0);
rgba(@R, @G, @B, @A); will output rgba(255, 0, 0, 1);
hsla(@R, @G, @B, @DA); will output hsla(255, 0, 0, 1.0);
~~~~

## Ui Map
![alt text](https://i.postimg.cc/X7M3vVYF/j-pick1.png)


## In App Guide
![alt text](https://i.postimg.cc/0j0txdNV/j-pick3.png)
![alt text](https://i.postimg.cc/J0LT9dRy/j-pick2.png)
![alt text](https://i.postimg.cc/J7NYbmQj/j-pick4.png)


## License
Payum is released under the [MIT License](LICENSE).
