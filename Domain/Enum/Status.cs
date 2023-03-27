namespace Domain.Enum;

public enum Status : byte
{
    Draft = 1,
    Reject = 2,
    Published = 3,

    Deleted = 4,
    NotDeleted = 5
}