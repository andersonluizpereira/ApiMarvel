FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["IntegrationMarvelCommicsApi/IntegrationMarvelCommics.Api.csproj", "IntegrationMarvelCommicsApi/"]
COPY ["../IntegrationMarvel.Api.CrossCutting/IntegrationMarvelCommics.Api.CrossCutting.csproj", "../IntegrationMarvel.Api.CrossCutting/"]
COPY ["../IntegrationMarvelCommics.Api.Domain/IntegrationMarvelCommics.Api.Domain.csproj", "../IntegrationMarvelCommics.Api.Domain/"]
RUN dotnet restore "IntegrationMarvelCommicsApi/IntegrationMarvelCommics.Api.csproj"
COPY . .
WORKDIR "/src/IntegrationMarvelCommicsApi"
RUN dotnet build "IntegrationMarvelCommics.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IntegrationMarvelCommics.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IntegrationMarvelCommics.Api.dll"]