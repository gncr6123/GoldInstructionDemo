using Domain.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace Infrastructure.Scheduler
{
    public class Scheduler : Domain.Core.Interfaces.IScheduler, IDisposable
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler;
        private readonly IServiceScopeFactory _scopeFactory;

        public Scheduler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _schedulerFactory = new StdSchedulerFactory();
            InitializeSchedulerAsync().Wait();
        }

        private async Task InitializeSchedulerAsync()
        {            
            _scheduler = await _schedulerFactory.GetScheduler();
            await _scheduler.Start();
        }

        public async Task ScheduleAsync(string jobId, DateTime executionTime, Func<INotificationUoW,Task> callback)
        {
            var job = JobBuilder.Create<CallbackJob>()
                .WithIdentity(jobId)
                .Build();

            job.JobDataMap["Callback"] = callback;            
            job.JobDataMap["ScopeFactory"] = _scopeFactory;

            var trigger = Quartz.TriggerBuilder.Create()
                .WithIdentity(jobId)
                .StartAt(executionTime)
                .Build();

            await _scheduler.ScheduleJob(job, trigger);
        }

        public async Task CancelAsync(string jobId)
        {
            var jobKey = new JobKey(jobId);
            if (await _scheduler.CheckExists(jobKey))
            {
                await _scheduler.DeleteJob(jobKey);
            }
        }

        public void Dispose()
        {
            _scheduler?.Shutdown(); // Scheduler'ı kapatıyoruz
            _scheduler = null;
        }
        
        private class CallbackJob : IJob
        {
            
            public async Task Execute(IJobExecutionContext context)
            {
                if (context.MergedJobDataMap["Callback"] is Func<INotificationUoW, Task> callback)
                {
                    var scopeFactory = context.MergedJobDataMap["ScopeFactory"] as IServiceScopeFactory;

                    if (scopeFactory != null)
                    {
                        // Scope oluşturuyoruz
                        using (var scope = scopeFactory.CreateScope())
                        {
                            // DI container'dan unit of work bağımlılığını alıyoruz
                            var unitOfWork = scope.ServiceProvider.GetRequiredService<INotificationUoW>();

                            // Callback fonksiyonunu çağırıyoruz
                            await callback(unitOfWork);
                        }
                    }
                }
            }
        }
    }
}
