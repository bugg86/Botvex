FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /botvex
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Botvex.API/Botvex.API.csproj", "src/Botvex.API/"]
COPY ["Botvex.DB/Botvex.DB.csproj", "src/Botvex.DB/"]
RUN dotnet restore "src/Botvex.API/Botvex.API.csproj"
COPY . .
WORKDIR "/src/Botvex.API"
RUN dotnet build  -c $BUILD_CONFIGURATION -o /botvex/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish  -c $BUILD_CONFIGURATION -o /botvex/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /botvex
COPY --from=publish /botvex/publish .
ENTRYPOINT ["dotnet", "Botvex.API.dll", "--server.urls", "https://+:5000"]
