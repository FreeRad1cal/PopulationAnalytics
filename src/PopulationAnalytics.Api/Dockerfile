FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
COPY ["src/PopulationAnalytics.Api/PopulationAnalytics.Api.csproj", "./PopulationAnalytics.Api/"]
RUN dotnet restore "./PopulationAnalytics.Api/PopulationAnalytics.Api.csproj"
COPY . .
WORKDIR "/app/src/PopulationAnalytics.Api"
RUN dotnet restore

RUN dotnet build "./PopulationAnalytics.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./PopulationAnalytics.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PopulationAnalytics.Api.dll"]