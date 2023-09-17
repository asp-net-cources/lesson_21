namespace Lesson21.Jobs;

public class SimpleJob: IHostedService, IDisposable
{
    private readonly ILogger<SimpleJob> _logger;
    private Task _executedTask;
    private CancellationTokenSource _tokenSource;

    public SimpleJob(ILogger<SimpleJob> logger)
    {
        _logger = logger;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start simple job");

        _tokenSource = new CancellationTokenSource();
        _executedTask = await Task.Factory.StartNew(async () =>
        {
            while (!_tokenSource.Token.IsCancellationRequested)
            {
                await Task.Delay(1000);
                _logger.LogInformation("We are working!");
            }
            _logger.LogInformation("Task was completed");
        });
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _tokenSource.Cancel();
        await _executedTask;

        _logger.LogInformation("Stop simple job");
    }

    public void Dispose()
    {
    }
}