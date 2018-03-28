#!/bin/bash

git pull

name=arknotifications_$(date +%Y%m%d)-$(git rev-parse --verify --short HEAD)
dotnet restore src/ArkNotifications && dotnet publish -c Release src/ArkNotifications

docker build -t $name .
docker run -h ark1 -dt $name /app/run-app.sh
docker run -h ark2 -dt $name /app/run-app.sh
