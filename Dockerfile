# syntax=docker/dockerfile:1

# Jeśli build Ci nie przejdzie, zmień 8.0 na 7.0 albo 6.0 zgodnie z TargetFramework w csproj
ARG DOTNET_VERSION=8.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build
WORKDIR /src

# skopiuj solucję i csproj (lepsze cache restore)
COPY AutoFix.sln ./
COPY AutoFix.PortalWWW/AutoFix.PortalWWW.csproj AutoFix.PortalWWW/
COPY AutoFix.Data/AutoFix.Data.csproj AutoFix.Data/
COPY AutoFix.Intranet/AutoFix.Intranet.csproj AutoFix.Intranet/

RUN dotnet restore AutoFix.PortalWWW/AutoFix.PortalWWW.csproj

# reszta kodu
COPY . .

WORKDIR /src/AutoFix.PortalWWW
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app

COPY --from=build /app/publish ./
COPY entrypoint.sh ./entrypoint.sh
RUN chmod +x ./entrypoint.sh

ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 10000

ENTRYPOINT ["./entrypoint.sh"]

