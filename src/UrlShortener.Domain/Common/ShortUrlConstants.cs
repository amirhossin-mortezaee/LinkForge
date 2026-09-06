namespace UrlShortener.Domain.Common;

/// <summary>
/// Single Source of Truth برای تمام محدودیت‌های عددی مربوط به ShortUrl.
/// هر بار قبل از نوشتن یه عدد Hardcode جدید مرتبط با ShortUrl،
/// اول اینجا رو چک کن که از قبل تعریف نشده باشه.
/// </summary>
public static class ShortUrlConstants
{
    /// <summary>
    /// طول واقعی کدهایی که IShortCodeGenerator تولید می‌کنه (پیش‌فرض ۶).
    /// </summary>
    public const int GeneratedShortCodeLength = 6;

    /// <summary>
    /// حداکثر طول مجاز برای CustomAlias که کاربر خودش انتخاب می‌کنه.
    /// باید >= GeneratedShortCodeLength و <= ShortCodeMaxLength باشه.
    /// </summary>
    public const int CustomAliasMaxLength = 15;

    /// <summary>
    /// حداکثر طول ستون ShortCode توی دیتابیس (باید دقیقاً با
    /// HasMaxLength در ShortUrlConfiguration یکی باشه).
    /// </summary>
    public const int ShortCodeMaxLength = 20;

    /// <summary>
    /// حداکثر طول مجاز برای URL اصلی که کاربر وارد می‌کنه.
    /// </summary>
    public const int OriginalUrlMaxLength = 2048;

    /// <summary>
    /// تعداد پیش‌فرض آیتم‌ها در هر صفحه (Pagination).
    /// </summary>
    public const int DefaultPageSize = 10;

    /// <summary>
    /// حداکثر تعداد آیتم‌های قابل درخواست در هر صفحه.
    /// </summary>
    public const int MaxPageSize = 100;
}