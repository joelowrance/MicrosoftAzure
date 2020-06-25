#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Identity/CarsIsland.Identity.API/CarsIsland.Identity.API.csproj", "Identity/CarsIsland.Identity.API/"]
RUN dotnet restore "Identity/CarsIsland.Identity.API/CarsIsland.Identity.API.csproj"
COPY . .
WORKDIR "/src/Identity/CarsIsland.Identity.API"
RUN dotnet build "CarsIsland.Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarsIsland.Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarsIsland.Identity.API.dll"]