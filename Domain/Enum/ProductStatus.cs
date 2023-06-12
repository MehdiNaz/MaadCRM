namespace Domain.Enum;

/// <summary>
/// .این ایـــنام برای محصولات به کار می رود
/// </summary>

public enum ProductStatus : byte
{
    Draft = 1,
    Reject = 2,
    Published = 3,
    Deleted = 4,
    Show = 5,
}