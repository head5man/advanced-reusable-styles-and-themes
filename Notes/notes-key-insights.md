### Main resource dictionary
- Provide single resource dictionary for developers to include
- provide both implicit and expliciti styles to apply automatically and allow extension and override

### NuGet setup
- Download and install nuget.exe (https://www.nuget.org/downloads) locally to C:\NuGet
- unblock nuget.exe from file properties
- Add install path to environment variable Path
- Run command `nuget spec` in the project folder to create <project-name>.nuspec 
- Setup nuget package build in project setup `Post-build event command line`
```
if $(ConfigurationName) == Release (
  nuget pack "$(ProjectPath)" -Properties Configuration=Release
  xcopy "$(TargetDir)"*.nupkg "C:\NuGet" /C /Y
)
```

### Using the resources as project reference (no NuGet package)
- Create application project
- Reference Globomantics.UI.WPF
- Merge in main resource dictionary
<ResourceDictionary Source="/Globomantics.UI.WPF;component/Themes/Globomantics.UI.WPF.xaml"/>
`component` referenced by assembly

### Mastering control templates (blend)
- Creating a temporary project for extracting templates avoids messing up the main project and
provides a playground to fiddle with changes
#### Extracting templates
![Control template structure](ControlTemplateStructure.svg)
- `Objects and Timeline` extract template from controls context menu (RMB) and selecting `Edit Template->Edit copy`
- More information of control templates insides can be found from microsoft website e.g.
[button-styles-and-templates](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/button-styles-and-templates)
#### Consistent formatting with XAML styler-extension
Options:
* Attribute tolerance: 1
* Newline exemption elements += Setter, Style, ControlTemplate, SolidColorBrush
* First-line attributes: x:Class, x:Key, x:name

#### Visual state manager problems
Changing theme from "light.xaml" -> "dark.xaml" was not setting the correct mouseover.
This is due to setting resources to storyboard get 'frozen'.
>Solution:
Adding borders to template for mouseOver and pressed in Collapsed state and setting visibility in storyboard.
