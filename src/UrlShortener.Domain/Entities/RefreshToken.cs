using System;

namespace UrlShortener.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; private set; }
        public string Token { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsRevoked { get; private set; }

        public bool IsActive => !IsRevoked && ExpiresAt > DateTime.UtcNow;

        private RefreshToken()
        {
            Token = string.Empty;
        }

        public static RefreshToken Create(Guid userId, string token, DateTime expiresAt)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId نمی‌تونه خالی باشه.", nameof(userId));

            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Token نمی‌تونه خالی باشه.", nameof(token));

            if (expiresAt <= DateTime.UtcNow)
                throw new ArgumentException("تاریخ انقضا باید در آینده باشه.", nameof(expiresAt));

            return new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Token = token,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = expiresAt,
                IsRevoked = false
            };
        }

        public void Revoke()
        {
            if (IsRevoked)
                return;

            IsRevoked = true;
        }
    }
}
