﻿# Path Test Case

Builds, (re)creates, starts, and attaches to containers for a service. Run containers in the background.

Execute "docker-compose up -d" on Api

dotnet ef migrations add initialMigration --startup-project ../src/Path.TestCase.Api/Path.TestCase.Api.csproj
dotnet ef database update --startup-project ../src/Path.TestCase.Api/Path.TestCase.Api.csproj

Run tests while docker container is active and running

## Requirements

- .Net Core 3.1 Runtime
- Docker & Docker Compose

## Technologies

- .Net Core 3.1
- Docker & Docker Compose
- Clean Architecture
- Swagger
- MediatR
- SignalR
- AutoMapper
- Redis
- Postgres

- Api Versioning
- ResponseWrapper
- ModelStateValidation