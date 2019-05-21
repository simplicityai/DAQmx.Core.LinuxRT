# DAQmx.Core.LinuxRT

This is a .NET Core library to allow the use of DAQmx in a .NET Core application running in NI Linux RT.

Preliminary benchmarking has shown that it has equivalent performance to LabVIEW.

## Snippets

To build a self-contained release for NI Linux RT:
```
dotnet publish -c Release -r linux-x64
```

To allow the compiled application to run:
```
chmod +x ./DAQmx.Core.LinuxRT.ConsoleApp
```

To be added to the .csproj to remove a runtime exception regarding globalization:
```
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Globalization.Invariant" Value="true" />
</ItemGroup>
```

## Links

https://ttu.github.io/dotnet-core-self-contained-deployments/
https://github.com/dotnet/corefx/blob/master/Documentation/architecture/globalization-invariant-mode.md
https://github.com/dotnet/core/blob/master/Documentation/self-contained-linux-apps.md