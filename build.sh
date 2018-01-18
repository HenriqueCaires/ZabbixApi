#!/bin/sh
nuget restore ZabbixApi.sln
nuget restore ZabbixApi/ZabbixApi.csproj
nuget restore ZabbixApiTests/ZabbixApiTests.csproj
msbuild ZabbixApi.sln