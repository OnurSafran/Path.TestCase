# Path Test Case

Builds, (re)creates, starts, and attaches to containers for a service. Run containers in the background.

Execute "docker-compose up -d" on Api

dotnet ef migrations add initialMigration --startup-project ../Api/Api.csproj
dotnet ef database update --startup-project ../Api/Api.csproj

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
- AutoMapper
- Fluent Validation
- Redis

- Api Versioning
- ResponseWrapper
- ExceptionHandler
- ModelStateValidation

- Tests