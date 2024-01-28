#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["FiapOrders.WebApi/FiapOrders.WebApi/FiapOrders.WebApi.csproj", "FiapOrders.WebApi/FiapOrders.WebApi/"]
COPY ["FiapOrders.WebApi/FiapOrders.WebApi.Domain/FiapOrders.WebApi.Domain.csproj", "FiapOrders.WebApi/FiapOrders.WebApi.Domain/"]
COPY ["FiapOrders.WebApi/FiapOrders.WebApi.Services/FiapOrders.WebApi.Services.csproj", "FiapOrders.WebApi/FiapOrders.WebApi.Services/"]
COPY ["FiapOrders.WebApi/FiapOrders.WebApi.Infra/FiapOrders.WebApi.Infra.csproj", "FiapOrders.WebApi/FiapOrders.WebApi.Infra/"]

COPY ["FiapOrders.Core/FiapOrders.Core.Domain/FiapOrders.Core.Domain.csproj", "FiapOrders.Core/FiapOrders.Core.Domain/"]

RUN dotnet restore "./FiapOrders.WebApi/FiapOrders.WebApi/FiapOrders.WebApi.csproj"
COPY . .
WORKDIR "/src/FiapOrders.WebApi/FiapOrders.WebApi"
RUN dotnet build "./FiapOrders.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FiapOrders.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FiapOrders.WebApi.dll"]