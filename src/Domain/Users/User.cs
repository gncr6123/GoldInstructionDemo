using Domain.Core.Entities;

namespace Domain.Users
{
    /// <summary>
    /// Kullanıcı iş modeli.
    /// </summary>
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        private User() { } // EF Core için eklendi

        public User(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("İsim alanı boş bırakılamaz", nameof(name));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Geçersiz e-mail adresi", nameof(email));

            Name = name;
            Email = email;
        }
    }
}
