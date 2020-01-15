FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

USER default

# copy csproj and restore as distinct layers
COPY ./WebServiceExample .
RUN dotnet restore

RUN dotnet publish -c Release -o /out

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "/out/WebServiceExample.dll"]
