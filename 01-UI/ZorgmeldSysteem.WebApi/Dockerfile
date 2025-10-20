# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopieer alle projectbestanden (ze staan allemaal in de root)
COPY ["ZorgmeldSysteem.WebApi.csproj", "."]
COPY ["ZorgmeldSysteem.Application.csproj", "."]
COPY ["ZorgmeldSysteem.Domain.csproj", "."]
COPY ["ZorgmeldSysteem.Infrastructure.csproj", "."]
COPY ["ZorgmeldSysteem.Persistence.csproj", "."]
COPY ["../../ZMS.Models.csproj", "."]

# Restore dependencies
RUN dotnet restore "ZorgmeldSysteem.WebApi.csproj"

# Kopieer alles en build
COPY . .
RUN dotnet publish "ZorgmeldSysteem.WebApi.csproj" -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ZorgmeldSysteem.WebApi.dll"]

