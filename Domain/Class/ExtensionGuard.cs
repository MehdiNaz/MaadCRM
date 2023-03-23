namespace Ardalis.GuardClauses;

public static class ExtensionGuard
{
    public static string MelliCode(this IGuardClause guardClause, string input, string parameterName)
    {
        if (input.Length != 10)
            throw new ArgumentException("کد ملی باید ۱۰ رقم باشد.", parameterName);
        return input;
    }

    public static string PhoneNo(this IGuardClause guardClause, string input, string parameterName)
    {
        if (input.Length != 10)
            throw new ArgumentException("شماره موبایل باید ۱۱ رقم باشد.", parameterName);
        return input;
    }
    public static int OtpCode(this IGuardClause guardClause, int input, string parameterName)
    {
        if (input >= 99999)
            throw new ArgumentException("کد باید ۶ رقم باشد.", parameterName);
        return input;
    }
    public static string Password(this IGuardClause guardClause, string input, string parameterName)
    {
        if (input.Length >= 8)
            throw new ArgumentException("کد باید ۶ رقم باشد.", parameterName);
        return input;
    }
}