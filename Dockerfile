# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Fase de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# Configuração do workspace
WORKDIR /src

# Copia apenas o arquivo de projeto e restaura as dependências
COPY ["next-world-api.csproj", "."]
RUN dotnet restore "next-world-api.csproj"

# Copia todo o restante do código
COPY . .

# Build do projeto
RUN dotnet build "next-world-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Fase de publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "next-world-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Fase final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "next-world-api.dll"]