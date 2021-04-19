FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=https://+;http://+ \
    ASPNETCORE_HTTPS_PORT=443 \
    ASPNETCORE_ENVIRONMENT=Docker \
    ASPNETCORE_Kestrel__Certificates__Default__Password="password" \
    ASPNETCORE_Kestrel__Certificates__Default__Path=/https/proxy.pfx

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["proxy.csproj", "./"]
RUN dotnet restore "./proxy.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "proxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "proxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY proxy.pfx /https/proxy.pfx
ENTRYPOINT ["dotnet", "proxy.dll"]
