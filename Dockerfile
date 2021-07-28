FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

# set up network
ENV ASPNETCORE_URLS http://+:8080

RUN mkdir /app
COPY src/ArkNotifications/bin/Release/net5.0/publish/ /app
COPY src/ArkNotifications/appsettings.json /app
WORKDIR /app
COPY run-app.sh /app
