FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Starglade.Api/Starglade.Api.csproj", "Starglade.Api/"]
COPY ["Starglade.Infrastructure/Starglade.Infrastructure.csproj", "Starglade.Infrastructure/"]
COPY ["Starglade.Core/Starglade.Core.csproj", "Starglade.Core/"]
COPY ["Starglade.Service/Starglade.Service.csproj", "Starglade.Service/"]
RUN dotnet restore "Starglade.Api/Starglade.Api.csproj"
COPY . .
WORKDIR "/src/Starglade.Api"
RUN dotnet build "Starglade.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Starglade.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Starglade.Api.dll"]