using System;
using Microsoft.Extensions.Configuration;

namespace JournalApp.Mobile.Helpers
{
 public static class AppConfig
 {
 private static IConfigurationRoot? _config;

 static AppConfig()
 {
 var builder = new ConfigurationBuilder()
 .AddEnvironmentVariables()
 .AddUserSecrets<AppConfig>(optional: true);
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
