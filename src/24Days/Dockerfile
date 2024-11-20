FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false\
    LC_ALL=en_US.UTF-8\
    LANG=en_US.UTF-8
EXPOSE 80
EXPOSE 443

# Create the required directory
RUN mkdir -p /etc/pki/ca-trust/source/anchors

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["24Days/24Days.csproj", "24Days/"]

RUN dotnet restore "Project.Web.UI/24Days.csproj"
COPY . .
WORKDIR "/src/24Days"
RUN dotnet build "24Days.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "24Days.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "24Days.dll"]
ENV ASPNETCORE_HTTP_PORTS=80