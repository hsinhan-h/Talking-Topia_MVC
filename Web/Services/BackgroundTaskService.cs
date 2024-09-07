using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class BackgroundTaskService : IHostedService, IDisposable
{
    private Timer _timer;

    // 當應用程式啟動時，執行的初始化邏輯
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Background service is starting.");

        // 設定一個計時器，每5秒執行一次指定的邏輯
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    // 執行定期的工作邏輯
    private void DoWork(object state)
    {
        Console.WriteLine("Background task is running at: " + DateTime.Now);
        // 可以在此處執行清理資料庫、發送通知、檢查狀態等任務
    }

    // 當應用程式關閉時，停止服務
    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Background service is stopping.");

        // 停止計時器
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    // 釋放資源
    public void Dispose()
    {
        _timer?.Dispose();
    }
}
