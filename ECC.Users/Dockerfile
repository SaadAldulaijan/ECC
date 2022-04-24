#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ECC.Users/nuget.config", "ECC.Users/"]
COPY ["ECC.Users/ECC.Users.csproj", "ECC.Users/"]
RUN dotnet restore "ECC.Users/ECC.Users.csproj"
COPY . .
WORKDIR "/src/ECC.Users"
RUN dotnet build "ECC.Users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECC.Users.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECC.Users.dll"]