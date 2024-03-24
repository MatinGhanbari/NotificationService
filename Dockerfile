#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Server/Server.csproj", "Server/"]
RUN dotnet restore "./Server/Server.csproj"
COPY ["Bootstrapper/Bootstrapper.csproj", "Bootstrapper/"]
RUN dotnet restore "./Bootstrapper/Bootstrapper.csproj"
COPY ["ConsumerApplication/ConsumerApplication.csproj", "ConsumerApplication/"]
RUN dotnet restore "./ConsumerApplication/ConsumerApplication.csproj"
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "./Core/Core.csproj"

COPY . .

WORKDIR "/src/Core"
RUN dotnet build "./Core.csproj" -c %BUILD_CONFIGURATION% -o /app/build
WORKDIR "/src/ConsumerApplication"
RUN dotnet build "./ConsumerApplication.csproj" -c %BUILD_CONFIGURATION% -o /app/build
WORKDIR "/src/Bootstrapper"
RUN dotnet build "./Bootstrapper.csproj" -c %BUILD_CONFIGURATION% -o /app/build
WORKDIR "/src/Server"
RUN dotnet build "./Server.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Server.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]