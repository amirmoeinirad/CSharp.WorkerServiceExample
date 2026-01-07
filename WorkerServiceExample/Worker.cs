namespace WorkerServiceExample
{
    // 'BackgroundService': An abstract base class for implementing long-running services that run in the background.
    // 'ILogger': A generic interface for logging messages.
    // The logger is injected into the Worker class via constructor injection.
    // The ILogger service is registered by default in the dependency injection container.
    public class Worker(ILogger<Worker> logger) : BackgroundService
    {
        // 'ExecuteAsync': This method is called automatically when the BackgroundService, in this case the Worker service, starts.
        // 'CancellationToken': A token (struct) that can be used to signal cancellation of the background task.
        // 'Task': Represents an asynchronous operation.
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Worker Service running at: {time}", DateTimeOffset.Now);
                }
                // 'Delay' method creates a task that completes after a specified time delay.
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
