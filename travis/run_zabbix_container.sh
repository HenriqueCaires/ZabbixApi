#!/bin/bash
docker pull zabbix/zabbix-appliance:ubuntu-4.0-latest
docker run --name myZabbix -p 43210:80 -d zabbix/zabbix-appliance:ubuntu-4.0-latest
docker ps -a
until curl --fail --silent --request POST --url http://MyZabbixServer:43210/api_jsonrpc.php  --header 'Content-Type: application/json'  --data '{"jsonrpc": "2.0", "method": "apiinfo.version", "params": [], "id": 1}'; do printf '.'; sleep 1; done