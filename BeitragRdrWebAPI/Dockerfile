#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BeitragRdrWebAPI/BeitragRdrWebAPI.csproj", "BeitragRdrWebAPI/"]
COPY ["BeitragRdrDataAccessLibrary/BeitragRdrDataAccessLibrary.csproj", "BeitragRdrDataAccessLibrary/"]
COPY ["BeitragRdr/BeitragRdr.csproj", "BeitragRdr/"]
COPY ["BeitragRdrUnitTest/BeitragRdrUnitTest.csproj", "BeitragRdrUnitTest/"]
RUN dotnet restore "BeitragRdrWebAPI/BeitragRdrWebAPI.csproj"
COPY . .
WORKDIR "/src/BeitragRdrWebAPI"
RUN test "BeitragRdrUnitTest.csproj" 
RUN dotnet build "BeitragRdrWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeitragRdrWebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeitragRdrWebAPI.dll"]