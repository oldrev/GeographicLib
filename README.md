# GeographicLib (C#)

[![NuGet Stats](https://img.shields.io/nuget/v/Sandwych.GeographicLib.svg)](https://www.nuget.org/packages/Sandwych.GeographicLib) 
[![Build status](https://ci.appveyor.com/api/projects/status/a6wqk46b7bjc6fyb?svg=true)](https://ci.appveyor.com/project/oldrev/geographiclib)


This is an attempt to port the Java version of GeographicLib to C#.

The current version is an almost Verbatim transfer of the Java code. 
This means that the comments too are in javadoc style and variables too will need renaming.
The plan to first change the comments to a C# style whenever I need to change anything in a class or when I need to understand how the class/method works

All in all, the code compiles without error and in general works ;)

For the original code head on to http://geographiclib.sourceforge.net/

Ported to .NET Standard 1.3 by Wei "oldrev" Li.

## Examples

The given example uses GeoAPI, although it was not necessary, this was done to showcase how simple it is to integrate in a common use case.

## License

This project is licensed under the MIT/X11 License, see LICENSE.md for the terms. 
