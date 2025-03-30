@echo off

REM Запуск Docker Compose
docker-compose up --build -d

IF %ERRORLEVEL% NEQ 0 (
    echo Failed to start Docker containers.
    exit /b %ERRORLEVEL%
)

echo Docker containers are up. Starting .NET MAUI application...
REM Запуск .NET MAUI приложения
dotnet run --project src\Presentation\MovieSearch.MAUI\MovieSearch.MAUI.csproj