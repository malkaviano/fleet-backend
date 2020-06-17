[![CodeFactor](https://www.codefactor.io/repository/github/malkaviano/fleet-backend/badge)](https://www.codefactor.io/repository/github/malkaviano/fleet-backend)

# fleet
Fleet API - Dev Test.

Dotnet version: 2.2.402

Build:
- dotnet restore
- dotnet build

Test:
- dotnet test

Run migrations before running:
- dotnet ef database update --startup-project Api/

Run locally:
- dotnet run --project Api/
- Swagger http://localhost:5000

Deploy (needs docker installed):
- Copy Dockerfile, docker-compose.yml and DockerMigrations outside the project folder (global.json conflict)
- Run docker-compose up -d --build(migrations may take some time to finish)
- Listens on port 80
