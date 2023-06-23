using L3Service.Com.Src;

namespace L3Service.Com
{
    public class L3WorkerService : BackgroundService
    {
        private readonly ILogger<L3WorkerService> _logger;

        public L3WorkerService(ILogger<L3WorkerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var testServ = new L3ComService();
            await testServ.StartAsync(stoppingToken);
            var tcs = new TaskCompletionSource<bool>();
            stoppingToken.Register(s => ((TaskCompletionSource<bool>)s).SetResult(true), tcs);
            await tcs.Task;
            await testServ.StopAsync(stoppingToken);
        }
    }
}