# I-Version

Provides classs and an interface for accessing assembly version information.

- Use with an IoC Container
- Use to stub/mock environment variable access in unit tests

Static methods be damned!

## Install

`dotnet add package I-Version`

https://www.nuget.org/packages/I-Version/

### How to pack
 - 'dotnet build'
 - 'dotnet pack'

 ### How to publish

 https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli

'dotnet nuget push ".\nupkg\dotgraphee.x.x.x.nupkg" -k <secret api key here> -s https://www.nuget.org'
