FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine

# set up network
ENV ASPNETCORE_URLS http://+:8080

RUN mkdir /app
COPY src/ArkNotifications/bin/Release/netcoreapp2.2/publish/ /app
COPY src/ArkNotifications/appsettings.json /app
WORKDIR /app
COPY run-app.sh /app
