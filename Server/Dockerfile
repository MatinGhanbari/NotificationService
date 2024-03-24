#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Server/Server.csproj", "Server/"]
COPY ["Bootstrapper/Bootstrapper.csproj", "Bootstrapper/"]
COPY ["ConsumerApplication/ConsumerApplication.csproj", "ConsumerApplication/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "./Server/Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "./Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust

ENTRYPOINT ["dotnet", "Server.dll"]