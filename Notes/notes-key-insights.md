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

