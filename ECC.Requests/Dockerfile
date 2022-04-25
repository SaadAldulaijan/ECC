#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["ECC.Requests/nuget.config", "ECC.Requests/"]
COPY ["ECC.Requests/ECC.Requests.csproj", "ECC.Requests/"]
RUN dotnet restore "ECC.Requests/ECC.Requests.csproj"
COPY . .
WORKDIR "/src/ECC.Requests"
RUN dotnet build "ECC.Requests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECC.Requests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECC.Requests.dll"]