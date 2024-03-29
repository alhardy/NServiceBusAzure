﻿using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Billing.Service
{
    class Program
    {
        static void Main(string[] args)
        {
           CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    var baseUrl = "https://messagingdemo001-kv.vault.azure.net/";
                    var tokenProvider = new AzureServiceTokenProvider();
                    
                    var kvClient = new KeyVaultClient((authority, resource, scope) => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));
                    builder.AddAzureKeyVault(baseUrl, kvClient, new DefaultKeyVaultSecretManager());
                })
                .ConfigureServices((hostContext, services) =>
                    {
                        services.Configure<Secrets>(s => ConfigurationBinder.Bind(hostContext.Configuration, (string) "Secrets", (object) s));
                        services.AddNServiceBus(hostContext.Configuration, typeof(Program).Assembly.GetName().Name);
                    });
        }
    }
}