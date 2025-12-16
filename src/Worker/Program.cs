using BigoBot;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<BotWorker>();
    })
    .Build();

await host.RunAsync();