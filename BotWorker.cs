using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace BigoBot;

public sealed class BotWorker : BackgroundService
{

    private ILogger<BotWorker> _logger { get; set; }

    public BotWorker(ILogger<BotWorker> logger)
    {
        _logger = logger;
    }
        
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("BigoBot started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            _logger.LogInformation("Tick...");
        }
    }
}