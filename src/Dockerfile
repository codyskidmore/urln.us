FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV DOTNET_URLS=http://+:80;https://+:443

VOLUME /Database

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./Url.Api.csproj", "./"]
RUN dotnet restore "./Url.Api.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Url.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Url.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Url.Api.dll"]
