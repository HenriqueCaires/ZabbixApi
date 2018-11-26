# ZabbixApi [![NuGet](https://img.shields.io/nuget/v/Zabbix.svg)](https://www.nuget.org/packages/Zabbix) [![Build Status](https://travis-ci.org/HenriqueCaires/ZabbixApi.svg?branch=master)](https://travis-ci.org/HenriqueCaires/ZabbixApi)

C# Zabbix Api to retrieve and modify the configuration of Zabbix

## Overview

This library allows you to make CRUD operations using Zabbix API.
You just need to instantiate the context and the service that you want and call the operation.Like that:

## Installing package

On the Package Manager Cosole type this to install:

```powershell
Install-Package Zabbix
```

## Using

Instantiate the context and the service that you want and call the operation:

```csharp
using(var context = new Context(url, user, password))
{
  var host = context.Hosts.GetByName("myHost");
}
```

You can make your own query too, like that:

```csharp
using(var context = new Context(url, user, password))
{
  var host = context.Hosts.Get(new {
      name = "myHost"
  });
}
```

Or that:

```csharp
using (var context = new Context(url, user, password))
{
    var host2 = context.Hosts.Get(new
    {
        hostid = "1"
    });
}
```

## Configuring via the `appsettings.json` file

Instead of specifying the configuration in the constructor the `appsettings.json` file can be used like that:

```json
{
    "ZabbixApi": {
        "url": "http://MyZabbixServer/zabbix/api_jsonrpc.php",
        "user": "Admin",
        "password": "zabbix"
    }
}

```

The empty constructor can then be used:

```csharp
using(var context = new Context())
{
  // ...
}
```
