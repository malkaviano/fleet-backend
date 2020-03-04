FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

LABEL maintainer="Rafael Karayannopoulos 'malkaviano'"

RUN git clone https://github.com/malkaviano/fleet-backend.git /myapp/

RUN rm /myapp/global.json

RUN cp -R /myapp/* .

WORKDIR /myapp

# Copy csproj and restore as distinct layers
RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

COPY --from=build-env /myapp/Api/out /app

WORKDIR /app

ENTRYPOINT ["dotnet", "Api.dll"]
