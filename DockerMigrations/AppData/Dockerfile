FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

LABEL maintainer="Rafael Karayannopoulos 'malkaviano'"

RUN git clone https://github.com/malkaviano/fleet-backend.git /myapp/

RUN rm /myapp/global.json

RUN cp -R /myapp/* .

WORKDIR /myapp

RUN dotnet restore

ENTRYPOINT dotnet ef database update --project Api/
