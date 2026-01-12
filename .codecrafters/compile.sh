#!/bin/sh
#

set -e # Exit on failure

dotnet build --configuration Release --output /tmp/codecrafters-build-csharp codecrafters-shell.csproj
