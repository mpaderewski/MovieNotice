#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8088
EXPOSE 4436

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MovieNotice.API/MovieNotice.API.csproj", "MovieNotice.API/"]
RUN dotnet restore "MovieNotice.API/MovieNotice.API.csproj"
COPY . .
WORKDIR "/src/MovieNotice.API"
RUN dotnet build "MovieNotice.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieNotice.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieNotice.API.dll"]