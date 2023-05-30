FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS restore
WORKDIR /src
COPY ["presentation/CleanArchitecture.Template.RestApi/CleanArchitecture.Template.RestApi.csproj", "presentation/CleanArchitecture.Template.RestApi/"]
RUN dotnet restore "presentation/CleanArchitecture.Template.RestApi/CleanArchitecture.Template.RestApi.csproj"
COPY . .

FROM restore AS dev
WORKDIR "/src/presentation/CleanArchitecture.Template.RestApi"
CMD dotnet watch run  

FROM restore AS build
WORKDIR "/src/presentation/CleanArchitecture.Template.RestApi"
RUN dotnet build "CleanArchitecture.Template.RestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.Template.RestApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS prod
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.Template.RestApi.dll"]