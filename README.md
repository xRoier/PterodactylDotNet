![Banner](https://raw.githubusercontent.com/Winter/PterodactylDotNet/master/.github/resources/banner.png)

![](https://img.shields.io/github/workflow/status/Winter/PterodactylDotNet/Publish%20to%20Nuget?color=light-green&label=release&style=for-the-badge) 
![](https://img.shields.io/github/workflow/status/Winter/PterodactylDotNet/Develop%20Build?color=light-green&label=Develop&style=for-the-badge)
![](https://img.shields.io/nuget/v/pterodactyldotnet?color=light-green&style=for-the-badge)
![](https://img.shields.io/nuget/dt/PterodactylDotNet?color=light-green&style=for-the-badge)

# PterodactylDotNet
A .NET Library for communicating with the Pterodactyl Panel

## Installation

#### Powershell
```
Install-Package PterodactylDotNet
```

#### DotNet CLI
```
dotnet add package PterodactylDotNet
```

## Basic Usage
```csharp
using PterodactylDotNet;
using PterodactylDotNet.Models.V10;

var api = new PterodactylApi("https://panel.example.org", "example_api_key", PterodactylTokenType.Client);
var users = await api.Application.Users.GetUsersAsync();

foreach (var user in users) {
  Console.WriteLine("First Name: {0}, Last Name: {1}", user.FirstName, user.LastName);
}
```

## License
MIT License.
