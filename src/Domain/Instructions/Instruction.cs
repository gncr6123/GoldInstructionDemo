using Domain.Core.Entities;

namespace Domain.Instructions
{
    /// <summary>
    /// Talimat iş modeli.
    /// Kullanıcının bir talimatını temsil eder.
    /// </summary>
    public class Instruction : BaseEntity
    {
        /// <summary>
        /// Talimatı veren kullanıcının kimliği.
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Talimatın işlenmesi gereken ayın günü.
        /// </summary>
        public int DayOfMonth { get; private set; }

        /// <summary>
        /// Talimatın tutarı.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Talimatın mevcut durumu.
        /// </summary>
        public InstructionStatus Status { get; private set; }

        /// <summary>
        /// Yeni bir talimat oluşturur.
        /// </summary>
        /// <param name="userId">Kullanıcı kimliği.</param>
        /// <param name="dayOfMonth">Talimat günü (1-28 arası).</param>
        /// <param name="amount">Talimat tutarı.</param>
        public Instruction(Guid userId, int dayOfMonth, decimal amount)
        {
            if (dayOfMonth < 1 || dayOfMonth > 28)
                throw new ArgumentOutOfRangeException(nameof(dayOfMonth), "Ayın 1. ve 28. günleri arasına talimat verebilirsiniz.");

            if (amount < 500 || amount > 99999)
                throw new ArgumentOutOfRangeException(nameof(amount), "Tutal 500 TL ile 99.999 TL arasında olmalıdır.");

            UserId = userId;
            DayOfMonth = dayOfMonth;
            Amount = amount;
            Status = InstructionStatus.Active;
        }

        /// <summary>
        /// Talimatı tamamlar.
        /// </summary>
        public void Complete()
        {
            if (Status != InstructionStatus.Active)
                throw new InvalidOperationException("Sadece aktif talimatlar tamamlanabilir.");

            Status = InstructionStatus.Completed;
            UpdateTimestamp();
        }

        /// <summary>
        /// Talimatı iptal eder.
        /// </summary>
        public void Cancel()
        {
            if (Status != InstructionStatus.Active)
                throw new InvalidOperationException("Sadece aktif talimatlar iptal edilebilir.");

            Status = InstructionStatus.Canceled;
            UpdateTimestamp();
        }

        /// <summary>
        /// Talimatın durumunu resetler.
        /// </summary>
        public void Reset()
        {
            Status = InstructionStatus.Active;
            UpdateTimestamp();
        }

        /// <summary>
        /// Talimatın durumunu kontrol eder.
        /// </summary>
        /// <returns>Talimat aktif mi?</returns>
        public bool IsActive()
        {
            return Status == InstructionStatus.Active;
        }
    }
}
