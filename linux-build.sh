#!/bin/bash
git pull
name=arknotifications_$(date +%Y%m%d)-$(git rev-parse --verify --short HEAD)
dotnet restore src/ArkNotifications && dotnet publish -c Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained=true src/ArkNotifications

docker build -t $name .
docker run -h ark1 -dt $name
