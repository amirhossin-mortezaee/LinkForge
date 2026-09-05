namespace UrlShortener.Domain.Entities
{
    public class ShortUrl
    {
        // ---------- Properties: فقط از داخل کلاس قابل تغییرن ----------
        public Guid Id { get; private set; }
        public string OriginalUrl { get; private set; }
        public string ShortCode { get; private set; }
        public Guid? UserId { get; private set; }
        public int ClickCount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ExpiresAt { get; private set; }
        public bool IsActive { get; set; }

        // ---------- Constructor خالی: فقط برای EF Core ----------

        private ShortUrl()
        {
            // EF Core موقع خوندن از دیتابیس، از همین constructor استفاده می‌کنه
            // (از طریق Reflection) و بعد property هارو خودش پر می‌کنه.
            // بدنه خالیه چون مقداردهی واقعی جای دیگه‌ایه.

            OriginalUrl = string.Empty;
            ShortCode = string.Empty;
        }

        // ---------- Constructor اصلی: فقط از داخل Create صدا زده می‌شه ----------

        private ShortUrl(Guid id, string originalUrl, string shortCode, Guid? userId,
            DateTime createdAt, DateTime? expiresAt, bool isActive, int clickCount)
        {
            Id = id;
            OriginalUrl = originalUrl;
            ShortCode = shortCode;
            UserId = userId;
            CreatedAt = createdAt;
            ExpiresAt = expiresAt;
            IsActive = isActive;
            ClickCount = clickCount;
        }

        // ---------- Factory Method: تنها راه ساخت یه ShortUrl معتبر ----------
        public static ShortUrl Create(string originalUrl, string shortCode, Guid? userId,
            DateTime? expiresAt)
        {
            if (string.IsNullOrWhiteSpace(originalUrl))
                throw new ArgumentException("OriginalUrl نمی‌تونه خالی باشه.", 
                    nameof(originalUrl));

            if (string.IsNullOrWhiteSpace(shortCode))
                throw new ArgumentException("ShortCode نمی‌تونه خالی باشه.",
                    nameof(originalUrl));

            if (expiresAt.HasValue && expiresAt.Value <= DateTime.UtcNow)
                throw new ArgumentException("ExpiresAt باید در آینده باشه.",
                    nameof(originalUrl));

            return new ShortUrl(
                id : Guid.NewGuid(),
                originalUrl : originalUrl,
                shortCode : shortCode,
                userId : userId,
                createdAt : DateTime.UtcNow,
                expiresAt : expiresAt,
                isActive : true,
                clickCount : 0
            );
        }

        // ---------- Behaviors: منطق دامنه، نه یه Service جدا ----------
        public void RegisterClick()
        {
            ClickCount++;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public bool IsExpired()
        {
            return ExpiresAt.HasValue && ExpiresAt.Value < DateTime.UtcNow;
        }

        public void UpdateExpiration(DateTime? newExpiresAt)
        {
            if (newExpiresAt.HasValue && newExpiresAt.Value <= DateTime.UtcNow)
            {
                throw new ArgumentException(
                    "Expiration date must be in the future.",
                    nameof(newExpiresAt));
            }

            ExpiresAt = newExpiresAt;
        }
    }
}
