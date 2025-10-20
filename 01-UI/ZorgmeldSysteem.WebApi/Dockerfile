# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopieer alle projectbestanden vanuit de root
COPY ["01-UI/ZorgmeldSysteem.WebApi/ZorgmeldSysteem.WebApi.csproj", "01-UI/ZorgmeldSysteem.WebApi/"]
COPY ["ZorgmeldSysteem.Application.csproj", "."]
COPY ["ZorgmeldSysteem.Domain.csproj", "."]
COPY ["ZorgmeldSysteem.Infrastructure.csproj", "."]
COPY ["ZorgmeldSysteem.Persistence.csproj", "."]
COPY ["ZMS.Models.csproj", "."]

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

