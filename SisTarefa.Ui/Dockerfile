#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:8081

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SisTarefa.Ui/SisTarefa.Ui.csproj", "SisTarefa.Ui/"]
COPY ["SisTarefa.Infra.Data/SisTarefa.Infra.Data.csproj", "SisTarefa.Infra.Data/"]
COPY ["SisTarefa.Domain/SisTarefa.Domain.csproj", "SisTarefa.Domain/"]
COPY ["SisTarefa.Ioc/SisTarefa.Ioc.csproj", "SisTarefa.Ioc/"]
COPY ["SisTarefa.Api/SisTarefa.Api.csproj", "SisTarefa.Api/"]
RUN dotnet restore "SisTarefa.Ui/SisTarefa.Ui.csproj"
COPY . .
WORKDIR "/src/SisTarefa.Ui"
RUN dotnet build "SisTarefa.Ui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SisTarefa.Ui.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SisTarefa.dll"]
