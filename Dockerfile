FROM microsoft/dotnet:3.1-aspnetcore-runtime-alpine

# set up network
ENV ASPNETCORE_URLS http://+:8080

RUN mkdir /app
COPY src/ArkNotifications/bin/Release/netcoreapp3.1/publish/ /app
COPY src/ArkNotifications/appsettings.json /app
WORKDIR /app
COPY run-app.sh /app
