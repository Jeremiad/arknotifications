FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

# set up network
ENV ASPNETCORE_URLS http://+:8080

RUN mkdir /app
COPY src/ArkNotifications/bin/Release/net6.0/publish/ /app
COPY src/ArkNotifications/appsettings.json /app
WORKDIR /app
COPY run-app.sh /app
