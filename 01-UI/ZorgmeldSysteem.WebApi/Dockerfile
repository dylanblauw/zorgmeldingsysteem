# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopieer projectbestanden met juiste paden
COPY ["01-UI/ZorgmeldSysteem.WebApi/ZorgmeldSysteem.WebApi.csproj", "01-UI/ZorgmeldSysteem.WebApi/"]
COPY ["02-Core/ZorgmeldSysteem.Application/ZorgmeldSysteem.Application.csproj", "02-Core/ZorgmeldSysteem.Application/"]
COPY ["02-Core/ZorgmeldSysteem.Domain/ZorgmeldSysteem.Domain.csproj", "02-Core/ZorgmeldSysteem.Domain/"]
COPY ["03-Infrastructure/ZorgmeldSysteem.Infrastructure/ZorgmeldSysteem.Infrastructure.csproj", "03-Infrastructure/ZorgmeldSysteem.Infrastructure/"]
COPY ["03-Infrastructure/ZorgmeldSysteem.Persistence/ZorgmeldSysteem.Persistence.csproj", "03-Infrastructure/ZorgmeldSysteem.Persistence/"]
COPY ["ZMS.Models/ZMS.Models.csproj", "ZMS.Models/"]

# Restore dependencies
RUN dotnet restore "01-UI/ZorgmeldSysteem.WebApi/ZorgmeldSysteem.WebApi.csproj"

# Kopieer alle code en build
COPY . .
WORKDIR /src/01-UI/ZorgmeldSysteem.WebApi
RUN dotnet publish "ZorgmeldSysteem.WebApi.csproj" -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ZorgmeldSysteem.WebApi.dll"]

