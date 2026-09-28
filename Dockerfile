# syntax=docker/dockerfile:1

# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only project files first so `dotnet restore` is cached until a dependency
# actually changes, rather than on every source edit.
COPY NDDC-Website-2024-App.sln ./
COPY NDDC-Website-2024/NDDC-Website-2024.csproj      NDDC-Website-2024/
COPY NddcWebsiteLibrary/NddcWebsiteLibrary.csproj   NddcWebsiteLibrary/
COPY EFCore-Lib/EFCore-Lib.csproj                   EFCore-Lib/

RUN dotnet restore NDDC-Website-2024/NDDC-Website-2024.csproj

COPY . .

RUN dotnet publish NDDC-Website-2024/NDDC-Website-2024.csproj \
        --no-restore \
        -c Release \
        -o /app/publish \
        /p:UseAppHost=false

# ---------- runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Must run as root, so it goes BEFORE `USER`.
# Lets the container negotiate with older SQL Server TLS setups.
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/' /etc/ssl/openssl.cnf \
 && sed -i 's/CipherString = DEFAULT:@SECLEVEL=2/CipherString = DEFAULT:@SECLEVEL=0/' /etc/ssl/openssl.cnf \
 && grep -E "MinProtocol|CipherString" /etc/ssl/openssl.cnf

# Run unprivileged. The base image ships a built-in `app` user (UID 1654).
USER $APP_UID

COPY --from=build /app/publish .

# Render injects PORT (10000 for web services). Binding to that exact value keeps
# Render's HTTP health check and the container in agreement.
ENV ASPNETCORE_URLS=http://+:10000 \
    ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_HTTPS_PORT=443 \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 10000

ENTRYPOINT ["dotnet", "NDDC-Website-2024.dll"]
