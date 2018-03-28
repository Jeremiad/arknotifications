# Arknotifications
Save [Web notifications](https://ark.gamepedia.com/Web_Notifications) from Ark server to MS SQL Database and/or send them to Discord channel

## Requirements
* [.Net Core 2.0.x](https://www.microsoft.com/net/download/windows)
* Microsoft SQL Server

### Optional
* Discord

## Configuration
Configuration file name: appsettings.json

Sample file: [appsettings.sample.json](https://github.com/Jeremiad/arknotifications/blob/master/src/ArkNotifications/appsettings.sample.json)

## Building
```
dotnet restore src/ArkNotifications 
```
```
dotnet publish -c Release src/ArkNotifications
```

## Running
```
dotnet .\src\ArkNotifications\bin\Release\netcoreapp2.0\ArkNotifications.dll
```