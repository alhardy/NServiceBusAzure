# Messaging with NServiceBus

## Set your Azure Subscription

Set the Azure Subscription that you'll be working with.

```console
$ az login
$ az account list
$ az account set --subscription {Subscritpion Id}
```

## Setup required Azure resources

### Create the Azure Resource Group

```console
$ az group create -n "messagingdemo-rg" -l australiaeast
```

### Create the Azure Keyvault Instance

```console
$ az keyvault create -n "messagingdemo001-kv" -g "messagingdemo-rg" -l australiaeast
```

### Create the Azure ServiceBus Namespace

Creating the ServiceBus Namespace

```console
$ az servicebus namespace create --resource-group "messagingdemo-rg" --name "messagingdemo001sb" --location australiaeast
```

Add the ServiceBus connection string to keyvault

```console
$ az servicebus namespace authorization-rule keys list --resource-group "messagingdemo-rg" --namespace-name "messagingdemo001sb" --name RootManageSharedAccessKey --query primaryConnectionString --output tsv
$ az keyvault secret set --vault-name "messagingdemo001-kv" --name Secrets--ServiceBusConnectionString --value "{Service Bus Connection String}"
```

### Requests

Post a `ValuesCommand` via the API subscribed to by the Backend.

```
curl -d '["value1"]' -H 'Content-Type: application/json' -X POST https://localhost:5000/command
```

### Overview

![Diagram](https://github.com/alhardy/MessagingDemo/blob/master/diagram.png)
