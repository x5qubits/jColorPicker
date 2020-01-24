# J Color Picker
<link rel="shortcut icon" type="image/x-icon" href="Resources/jColorPickerLogo.ico">

![Build Status Travis-CI](https://img.shields.io/appveyor/ci/x5Qubits/jColorPicker?style=flat-square)


**Regardless if you're a web developer or a programmer in the general sense, this nifty little app will help you get all the color code details you need**

Color palettes can sometimes be more than just their visual representation, especially in the world of programming. Take for instance Web design – an impressive range of corresponding codes are used to represent each color variation and working with the different classifications can sometimes be hectic. J Color Picker aims at providing a tool for easily identifying colors, save them as custom palettes and viewing their corresponding programming codes.


**Minimalist and elegant interface that carries an accessible layout**

The program features a stylish interface, which encapsulates all the required elements for working with color palettes. Although we appreciate the resizable layout, it would have been beneficial to also have options for selecting different views of the colors in the palette.

For those who are familiar with a classic “Photoshop approach” that involves a color dropper/picker tool, the program offers a handy alternative. All you need to do is simply hold and drag the crosshair to the preferred sampling area.

**Pick your color, save it as custom preset, and browse the extensive range of color codes**

Having selected a color by either using the color picker or the pre-defined colors, users can save it for later use. Furthermore, even the existing colors can also be edited and stored. Having the ability to use both numerical fields and sliders as input methods for the RGB and HSL values is a really nice touch.

A wide range of codes is available, from the classic RGB, up to Hexadecimal, HSL or HSLA. A very handy option offers auto-copy to the clipboard, making things easier when working with multiple apps.

**Useful utilitary that can help users save a lot of time when working with color palettes and seeking color codes**

J Color Picker is a valuable tool for those who work with color palettes and need an efficient way of identifying and viewing color codes. Simple enough yet capable, it offers a sampling tool as well as a decent range of pre-defined colors.

**Tags**

#Color Picker #Color Palette #CSS #Color Code #Palette Dropper #Color HEX 

## Features
- Extensive range of color code formats:HEX, RGB, RGBA, HSB/HSV, HSL, and User Defined (Custom).
- List of palettes
- CSS-compatible color codes.
- User-defined hotkeys.
- High-DPI awareness.
- Multi-display support.
- No installation required. Just Color Picker is a portable application and can be run directly from a USB stick.
- Copying the color code to the clipboard with one mouse click or automatically.
- Optional stay-on-top behavior.

## Resources
* [Download Bins](https://github.com/x5qubits/jColorPicker/releases/)
* [Issue Tracker](https://github.com/x5qubits/jColorPicker/issues)

## Ui Map
![alt text](https://i.postimg.cc/X7M3vVYF/j-pick1.png)


## In App Guide
![alt text](https://i.postimg.cc/0j0txdNV/j-pick3.png)
![alt text](https://i.postimg.cc/J0LT9dRy/j-pick2.png)
![alt text](https://i.postimg.cc/J7NYbmQj/j-pick4.png)

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

## License
Payum is released under the [MIT License](LICENSE).
