FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["presentation/CleanArchitecture.Template.GrpcApi/CleanArchitecture.Template.GrpcApi.csproj", "presentation/CleanArchitecture.Template.GrpcApi/"]
RUN dotnet restore "presentation/CleanArchitecture.Template.GrpcApi/CleanArchitecture.Template.GrpcApi.csproj"
COPY . .
WORKDIR "/src/presentation/CleanArchitecture.Template.GrpcApi"
RUN dotnet build "CleanArchitecture.Template.GrpcApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.Template.GrpcApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.Template.GrpcApi.dll"]