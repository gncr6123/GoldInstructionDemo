using Domain.Notifications.Interfaces;

namespace Domain.Core.Interfaces
{
    public interface IScheduler
    {
        /// <summary>
        /// Belirtilen tarihte bir iş planlar.
        /// </summary>
        /// <param name="jobId">İşin benzersiz kimliği.</param>
        /// <param name="executionTime">İşin çalıştırılacağı tarih ve saat.</param>
        /// <param name="callback">Çalıştırılacak işlem.</param>
        Task ScheduleAsync(string jobId, DateTime executionTime, Func<INotificationUoW,Task> callback);

        /// <summary>
        /// Planlanan bir işi iptal eder.
        /// </summary>
        /// <param name="jobId">İptal edilecek işin benzersiz kimliği.</param>
        Task CancelAsync(string jobId);
    }
}
