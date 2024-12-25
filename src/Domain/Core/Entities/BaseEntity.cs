namespace Domain.Core.Entities
{

    /// <summary>
    /// Tüm varlıklar için temel sınıf.
    /// Ortak özellikler ve davranışlar burada tanımlanır.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Her varlık için benzersiz kimlik.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Varlığın oluşturulma tarihi.
        /// </summary>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// Varlığın en son güncellenme tarihi.
        /// </summary>
        public DateTime? UpdatedAt { get; protected set; }

        /// <summary>
        /// Varlığın silinme tarihi (Soft Delete için).
        /// </summary>
        public DateTime? DeletedAt { get; protected set; }

        /// <summary>
        /// Varlığın aktif olup olmadığını belirler (Soft Delete için).
        /// </summary>
        public bool IsDeleted { get; protected set; }

        /// <summary>
        /// Yeni bir varlık oluşturulduğunda, Id ve CreatedAt otomatik atanır.
        /// </summary>
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        /// <summary>
        /// Varlığın güncelleme zamanını ayarlar.
        /// </summary>
        public void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Varlığın soft delete ile işaretlenmesini sağlar.
        /// </summary>
        public void MarkAsDeleted()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Varlığın soft delete durumunu geri alır.
        /// </summary>
        public void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }

}
