FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS http://+:8080


FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["src/ArkNotifications/ArkNotifications.csproj", "src/ArkNotifications/"]
RUN dotnet restore "src/ArkNotifications/ArkNotifications.csproj"
COPY . .
WORKDIR "/src/src/ArkNotifications"
RUN dotnet build "ArkNotifications.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArkNotifications.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN adduser -DH web
USER web
COPY --from=publish /app/publish .
COPY src/ArkNotifications/appsettings.json /app
ENTRYPOINT ["dotnet", "ArkNotifications.dll"]