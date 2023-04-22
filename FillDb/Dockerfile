FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FillDb/FillDb.csproj", "FillDb/"]
RUN dotnet restore "FillDb/FillDb.csproj"
COPY . .
WORKDIR "/src/FillDb"
RUN dotnet build "FillDb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FillDb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FillDb.dll"]
