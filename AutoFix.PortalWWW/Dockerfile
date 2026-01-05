# ===== build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# kopiujemy sln + csproj, żeby restore był cache'owalny
COPY AutoFix.sln ./
COPY AutoFix.PortalWWW/AutoFix.PortalWWW.csproj AutoFix.PortalWWW/
COPY AutoFix.Data/AutoFix.Data.csproj AutoFix.Data/
COPY AutoFix.Intranet/AutoFix.Intranet.csproj AutoFix.Intranet/

RUN dotnet restore

# kopiujemy resztę kodu
COPY . .

# publish WWW
WORKDIR /src/AutoFix.PortalWWW
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ===== runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Render wystawia PORT jako env var, więc aplikacja MUSI na nim słuchać
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

CMD ["dotnet", "AutoFix.PortalWWW.dll"]
