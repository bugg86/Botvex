FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /botvex
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Botvex.API/Botvex.API.csproj", "Botvex.API/"]
COPY ["Botvex.DB/Botvex.DB.csproj", "Botvex.DB/"]
RUN dotnet restore "Botvex.API/Botvex.API.csproj"
COPY . .
WORKDIR "/src/Botvex.API"
RUN dotnet build "Botvex.API.csproj" -c $BUILD_CONFIGURATION -o /botvex/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Botvex.API.csproj" -c $BUILD_CONFIGURATION -o /botvex/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /botvex
COPY --from=publish /botvex/publish .
ENTRYPOINT ["dotnet", "Botvex.API.dll"]
