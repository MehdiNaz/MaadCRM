namespace Application;

public class DatePersian
{
    public static string ToPersian(DateTime date)
    {
        var persian = new PersianCalendar();
        var year = persian.GetYear(date);
        var month = persian.GetMonth(date);
        var day = persian.GetDayOfMonth(date);
        return year + "/" + month.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0') + " " + date.Hour +
               ":" + date.Minute;
    }

    public static string ToPersianDateTime(DateTime? date)
    {
        if (date == null)
        {
            return "";
        }

        var persian = new PersianCalendar();
        var year = persian.GetYear(date.Value);
        var month = persian.GetMonth(date.Value);
        var day = persian.GetDayOfMonth(date.Value);
        return year + "/" + month.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0') + " " +
               date.Value.ToString("HH:mm:ss tt");
    }

    public static string ToPersianDateTimeNew(DateTime? date)
    {
        if (date == null)
        {
            return "";
        }

        var persian = new PersianCalendar();
        var year = persian.GetYear(date.Value);
        var month = persian.GetMonth(date.Value);
        var day = persian.GetDayOfMonth(date.Value);
        return year + "/" + month.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0') + " " +
               date.Value.Hour.ToString().PadLeft(2, '0') + ":" + date.Value.Minute.ToString().PadLeft(2, '0');
    }

    public static string CalculateDate(DateTime date)
    {
        var diff = DateTime.Now - date;
        if (diff.Days >= 1)
        {
            return diff.Days + " روز پیش";
        }

        if (diff.Hours is <= 24 and >= 1)
        {
            return diff.Hours + " ساعت پیش";
        }

        if (diff.Minutes is <= 60 and >= 1)
        {
            return diff.Minutes + " دقیقه پیش";
        }

        return "لحظاتی پیش";
    }

    public static DateTime? PersianToDateTime(string date)
    {
        var persian = new PersianCalendar();
        if (string.IsNullOrWhiteSpace(date))
        {
            return null;
        }

        try
        {
            var year = Int32.Parse(date.Substring(0, 4));
            var month = Int32.Parse(date.Substring(5, 2));
            var day = Int32.Parse(date.Substring(8, 2));
            int hour;
            int minute;
            var second = 0;
            var millisecond = 0;
            //		"1395/03/05 18:5"
            try
            {
                hour = Int32.Parse(date.Substring(11, 2));
                minute = Int32.Parse(date.Substring(14, 2));
            }
            catch (Exception)
            {
                hour = 0;
                minute = 0;
            }

            return persian.ToDateTime(year, month, day, hour, minute, second, millisecond);
        }
        catch
        {
            return null;
        }
    }

    public static string ToPersianDate(DateTime? date)
    {
        if (date == null)
        {
            return string.Empty;
        }

        var persian = new PersianCalendar();
        var year = persian.GetYear(date.Value);
        var month = persian.GetMonth(date.Value);
        var day = persian.GetDayOfMonth(date.Value);
        return year + "/" + month.ToString().PadLeft(2, '0') + "/" + day.ToString().PadLeft(2, '0');
    }

    public static string GetPersianNumber(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return string.Empty;
        }

        for (var i = 48; i < 58; i++)
        {
            data = data.Replace(Convert.ToChar(i), Convert.ToChar(1728 + i));
        }

        return data;
    }
}