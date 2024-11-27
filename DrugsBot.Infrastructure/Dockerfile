FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DrugsBot.Infrastructure/DrugsBot.Infrastructure.csproj", "DrugsBot.Infrastructure/"]
RUN dotnet restore "DrugsBot.Infrastructure/DrugsBot.Infrastructure.csproj"
COPY . .
WORKDIR "/src/DrugsBot.Infrastructure"
RUN dotnet build "DrugsBot.Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DrugsBot.Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrugsBot.Infrastructure.dll"]
