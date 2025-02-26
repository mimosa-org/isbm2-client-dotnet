# ISBM2 Client .Net

A .Net Core library for OpenO&M ISBMv2 clients to invoke the services on an
ISBMv2 Service Provider.

See the [OpenO&M website](https://openoandm.org/isbm/) for the specification.

This project includes a high-level interface intended to be applicable for all
ISBMv2 client implementations as well as a REST specific implementation generated
from the published OpenAPI specification of the ISBM interfaces.
In the future a SOAP Web Services implementation will be generated an included.
Users of the client library will be able to select which implementation they
use in their projects.

In addition, this project includes a simple command-line application that
demonstrates usage of the ISBMv2 Rest Client implementation and allows various
interactions with an ISBMv2 Service Provider.

## Frameworks supported

 - .Net Core 6.0
 - TODO: expand and test on more framework variations

## Development

The example `BlazorServerExample` project, which demonstrates the usage of the client
library in a web application, uses Tailwind CSS v3 and will execute CSS pre-processor
as part of the build process.

To ensure that the build is successful, ensure `nodejs` and `npm` are installed and run

```
npm install -D tailwindcss@3
```

to ensure tailwindcss is installed as a development dependency.

## Getting/Publishing the NuGet package

The NuGet package for the Isbm2Client library is currently being published via GitHub
rather than [NuGet.org](https://www.nuget.org). To read or publish the package you
will need to configure the NuGet registry for the Isbm2Client package.

If you want to use the Isbm2Client package in your project:

1. Copy the `github-mimosa-org` package source from [nuget.config](./nuget.config)
   into the `nuget.config` file in your project.

2. Note that the package should be publicly available so auth credentials should
   not be required. However, if credentials are required:
    1. Set the environment variable `GH_USERNAME` to your GitHub username
    2. Set the environment variable `GH_TOKEN` to a GitHub Personal Access Token (classic)
       that you have generated with `read:packages` permission.


If you want to publish (**maintainers only**) a new version of the Isbm2Client
package to the NuGet registry:

1. Set the environment variable `GH_USERNAME` to your GitHub username
2. Set the environment variable `GH_TOKEN` to a GitHub Personal Access Token (classic)
   that you have generated with `write:packages` permission.
3. ```bat
   dotnet pack --configuration Release
   ```
4. ```bat
   dotnet nuget push "src/Isbm2Client/bin/Release/Isbm2Client.VERSION.nupkg" --api-key %GH_TOKEN% --source "github-mimosa-org"
   ```
   where `VERSION` is replaced with the version number being published.

## Contributing

The main repository for Isbm2Client is https://github.com/mimosa-org/isbm2-client-dotnet

If you would like to contribute to development, please:
1. Fork the repository
2. Make your changes in a branch
3. Create a pull request with a description of the new feature, bugfix, etc.
   of the contribution.

   > Note that not all pull requests will necessarily be merged into the main
   > repository. If you like, you could first open an issue discussing the
   > proposed change before implementing it. This will help ensure that any
   > contributions align with the overall goals of the project.

You may also open an issue, feature request, discussion, etc., in the repository's
issue tracker if you like.

# License

Copyright (c) 2025 Asset Institute, Assetricity, pitt&sherry, Synengco, University of South Australia

This software is released under the MIT License. See [LICENSE](./LICENSE.txt) for details.
