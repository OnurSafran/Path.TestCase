FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Path.TestCase.sln .
COPY src/Path.TestCase.Api/Path.TestCase.Api.csproj ./src/Path.TestCase.Api/
COPY src/Path.TestCase.Core/Path.TestCase.Core.csproj ./src/Path.TestCase.Core/
COPY src/Path.TestCase.Application/Path.TestCase.Application.csproj ./src/Path.TestCase.Application/
COPY src/Path.TestCase.Infrastructure/Path.TestCase.Infrastructure.csproj ./src/Path.TestCase.Infrastructure/
RUN dotnet restore

# Copy everything else and build
COPY src/Path.TestCase.Api/. ./Path.TestCase.Api
COPY src/Path.TestCase.Core/. ./Path.TestCase.Core
COPY src/Path.TestCase.Application/. ./Path.TestCase.Application
COPY src/Path.TestCase.Infrastructure/. ./Path.TestCase.Infrastructure

WORKDIR /app/Path.TestCase.Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/Path.TestCase.Api/out ./
ENTRYPOINT ["dotnet", "Path.TestCase.Api.dll"]