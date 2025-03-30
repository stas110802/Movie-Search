FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/MovieSearch.WebApi/MovieSearch.WebApi.csproj", "src/Presentation/MovieSearch.WebApi/"]
RUN dotnet restore "src/Presentation/MovieSearch.WebApi/MovieSearch.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Presentation/MovieSearch.WebApi"
RUN dotnet build "MovieSearch.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MovieSearch.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieSearch.WebApi.dll"]
