# Support package for SpecByExample extension 

NuGet package containing shared components for the SpecByExample extension. It contains the set of default control adapters and page adapters.

It is isolated into a package so that it can more easily be updated and extended by the community and have a lifecycle of its own.

## Building the packages

### Standard package
The standard package can be built by installing the [Nuget CLI](https://dist.nuget.org/index.html) and then run:
`nuget pack SpecByExample.Common.nuspec -properties Configuration=Debug`

### Debugging
There is also a [symbols package](https://docs.microsoft.com/en-us/nuget/create-packages/symbol-packages) available to support debugging with full sourcecode and pdb files.
You may also build the symbols package by running:
`nuget pack SpecByExample.Common.Symbols.nuspec -properties Configuration=Debug -Symbols`


