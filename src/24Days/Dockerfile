FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
ENV APP_UID=1000
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["24Days/24Days.csproj", "24Days/"]
RUN dotnet restore "./24Days/24Days.csproj"

COPY . .
WORKDIR "/src/24Days"

RUN dotnet build "./24Days.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./24Days.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER root
RUN mkdir -p /app/wwwroot/media && chown -R $APP_UID:$APP_UID /app/wwwroot/media

USER $APP_UID
ENTRYPOINT ["dotnet", "24Days.dll"]
