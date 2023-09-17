namespace Lesson21.Jobs;

public class NotSimpleJob: BackgroundService
{
    private readonly ILogger<NotSimpleJob> _logger;

    public NotSimpleJob(ILogger<NotSimpleJob> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
            _logger.LogInformation("NotSimple: We are working!");
        }
        _logger.LogInformation("NotSimple: Task was completed");
    }
}