# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopieer projectbestanden
COPY ["01-UI/ZorgmeldSysteem.WebApi/ZorgmeldSysteem.WebApi.csproj", "01-UI/ZorgmeldSysteem.WebApi/"]
COPY ["02-Core/02-Core.csproj", "02-Core/"]
COPY ["03-Infrastructure/03-Infrastructure.csproj", "03-Infrastructure/"]
COPY ["ZMS.Models/ZMS.Models.csproj", "ZMS.Models/"]

# Restore dependencies
RUN dotnet restore "01-UI/ZorgmeldSysteem.WebApi/ZorgmeldSysteem.WebApi.csproj"

# Kopieer alles en build
COPY . .
WORKDIR "/src/01-UI/ZorgmeldSysteem.WebApi"
RUN dotnet publish "ZorgmeldSysteem.WebApi.csproj" -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ZorgmeldSysteem.WebApi.dll"]

