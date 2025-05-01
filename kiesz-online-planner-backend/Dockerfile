FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["kiesz-online-planner-backend/kiesz-online-planner-backend.csproj", "kiesz-online-planner-backend/"]
RUN dotnet restore "kiesz-online-planner-backend/kiesz-online-planner-backend.csproj"
COPY . .
WORKDIR "/src/kiesz-online-planner-backend"
RUN dotnet build "kiesz-online-planner-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "kiesz-online-planner-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "kiesz-online-planner-backend.dll"]
