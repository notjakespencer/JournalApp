using System;
using Microsoft.Extensions.Configuration;

namespace JournalApp.ApiService.Helpers
{
 public static class ApiConfig
 {
 private static IConfigurationRoot? _config;

 static ApiConfig()
 {
 var builder = new ConfigurationBuilder()
 .AddEnvironmentVariables()
 .AddUserSecrets<ApiConfig>(optional: true);
 _config = builder.Build();
 }

 public static string Get(string key, string fallback = "")
 {
 return Environment.GetEnvironmentVariable(key)
 ?? _config?[key]
 ?? fallback;
 }
 }
}
