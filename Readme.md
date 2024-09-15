### Summary

Working through the steps in skills/pluralsight course [https://app.pluralsight.com/library/courses/wpf-advanced-reusable-styles-themes](https://app.pluralsight.com/library/courses/wpf-advanced-reusable-styles-themes/table-of-contents)

The course provides an excellent example of creating a runtime switchable theme(s) and an overview of working with, distributing and applying xaml styles in an client application.

I have mostly applied the changes introduced in the course chapters but have also taken the liberty to apply some personal preferences and improvements.
As an example of a preference or improvement is the reimplementation of the ThemeResource classes and the coupling with the resource keys.
The main goal being to make the theme implementantion reusable and customizable e.g. with json files containing the base key values.
While some might perceive this as a unnecessary complication of a perfectly working copy-paste pattern,
leveraging properties and base classes allows for a encapsulation of the themes within classes,
resulting in a more atomic and orderly theme loading.

Author of course materials:

https://app.pluralsight.com/profile/author/keith-harvey

http://keithharvey.com/

original contents of Readme.txt:
```
========================================================
Advanced Reusable Styles and Themes in WPF - Source Code
========================================================

To run the Globomantics.UI Dev app: 

* Open Globomantics.UI.sln in Visual Studio 
* Set the Dev project to be the start-up project
* Build and run

The TeRex app needs a Globomantics.UI.WPF NuGet package located in a local NuGet repo called Dev at C:\NuGet

* Make sure nuget.exe is available in your system path
* Make sure you have a C:\NuGet folder created on your system
* Open Globomantics.UI.sln in Visual Studio and set it to Release mode and build
    * This will create the Globomantics.UI.WPF NuGet package
* Open TeRex.sln in Visual Studio
* In Visual Studio check Tools > Options > NuGet Package Manager > Package Sources and
  make sure there is a source called Dev pointing to C:\NuGet
* Build and run
```
