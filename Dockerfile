FROM microsoft/dotnet:2.1-aspnetcore-runtime

# set up network
ENV ASPNETCORE_URLS http://+:8080

RUN apt-get update
RUN apt-get upgrade -y

RUN mkdir /app
COPY src/ArkNotifications/bin/Release/netcoreapp2.1/publish/ /app
COPY src/ArkNotifications/appsettings.json /app
WORKDIR /app
COPY run-app.sh /app
