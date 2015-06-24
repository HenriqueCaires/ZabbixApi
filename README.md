# ZabbixApi
C# Zabbix Api to retrieve and modify the configuration of Zabbix

# Overview
This library allows you to make CRUD operations using Zabbix API.
You just need to instantiate the context and the service that you want and call the operation.Like that:

# Installing package
On the Package Manager Cosole type this to install:
```
Install-Package Zabbix
```

# Configuring

Ajust the parameters on the config file:

```xml
<configuration>
  <appSettings>
    <add key="ZabbixApi.url" value="http://myZabbixServer/zabbix/api_jsonrpc.php" />
    <add key="ZabbixApi.user" value="Admin" />
    <add key="ZabbixApi.password" value="zabbix" />
  </appSettings>
</configuration>
```

# Using

Instantiate the context and the service that you want and call the operation:

```csharp
using(var context = new Context())
{
  var service = new HostService(context);
  var host = service.GetByName("myHost");
}
```

You can make your own query too, like that:

```csharp
using(var context = new Context())
{
  var service = new HostService(context);
  var host = service.Get(new {
      name = "myHost"
  });
}
```

Or that:

```csharp
using (var context = new Context())
{
    var service = new HostService(context);
    var host2 = service.Get(new
    {
        hostid = "1"
    });
}
```
