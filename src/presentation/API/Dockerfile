#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/presentation/API/API.csproj", "src/presentation/API/"]
COPY ["src/infrastructure/PersistenceLayer/PersistenceLayer.csproj", "src/infrastructure/PersistenceLayer/"]
COPY ["src/core/ApplicationLayer/ApplicationLayer.csproj", "src/core/ApplicationLayer/"]
COPY ["src/core/DomainLayer/DomainLayer.csproj", "src/core/DomainLayer/"]
RUN dotnet restore "src/presentation/API/API.csproj"
COPY . .
WORKDIR "/src/src/presentation/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]