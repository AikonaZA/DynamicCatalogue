var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.DynamicCatalogue_ApiService>("apiservice");

builder.AddProject<Projects.DynamicCatalogue_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    //.WithReference(cache)
    .WithReference(apiService);

builder.AddProject<Projects.Catalogue_API>("catalogue-api");

builder.AddProject<Projects.Ordering_API>("ordering-api");

builder.AddProject<Projects.Identity_API>("identity-api");

builder.AddProject<Projects.Basket_API>("basket-api");

builder.Build().Run();
