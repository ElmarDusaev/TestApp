#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestApp.WebApi/TestApp.WebApi.csproj", "TestApp.WebApi/"]
COPY ["TestApp.DataAccess/TestApp.DataAccess.csproj", "TestApp.DataAccess/"]
COPY ["TestApp.Domain/TestApp.Domain.csproj", "TestApp.Domain/"]
RUN dotnet restore "TestApp.WebApi/TestApp.WebApi.csproj"
COPY . .
WORKDIR "/src/TestApp.WebApi"
RUN dotnet build "TestApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestApp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApp.WebApi.dll"]