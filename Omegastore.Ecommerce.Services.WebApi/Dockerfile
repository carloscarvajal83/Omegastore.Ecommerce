#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Omegastore.Ecommerce.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /src/Omegastore.Ecommerce.Services.WebApi/out ./

ENTRYPOINT ["dotnet", "Omegastore.Ecommerce.Services.WebApi.dll"]