#!/bin/sh
nuget restore ZabbixApi.sln
xbuild ZabbixApi.sln /verbosity:minimal