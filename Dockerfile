# Imagem de build
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/published-app

# Imagem de tempo de execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT ["dotnet", "/app/SisTarefa.dll"]

# para buildar esteja :  C:\Projetos\SisTarefa\SisTarefa.Ui\bin\Debug\net6.0 
#                        dotnet build  
#                        Em program.cs  retirou o #if do swagger para rodar localmente