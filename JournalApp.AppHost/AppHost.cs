using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.JournalApp_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.JournalApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.JournalApp_Mobile>("journal-mobile");
    //.WithLaunchProfile(JournalApp_ApiService.Mobile);

builder.AddProject<Projects.JournalApp_AIAgent>("journalapp-aiagent");
    //.WithLaunchProfile(JournalApp_ApiService.Mobile);

builder.Build().Run();
