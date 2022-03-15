using System.Globalization;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string composite = "My name is {0, 0}";
        Console.WriteLine(string.Format(composite, "Catalina"));

        var uni = "UPT";
        var year = 3;
        Console.WriteLine($"I am a student at {uni} in year {year}.");

        StringBuilder sb = new StringBuilder("ABC");
        sb.AppendFormat("DEF{0}{1}", "G", "H");
        Console.WriteLine(sb.ToString());

        var name = "Gheorghioiu Alexandra-Catalina";
        string[] arr = name.Split(new char[] { ' ', '-' });
        Console.WriteLine(arr[0]);
        Console.WriteLine(arr[2]);

        var timespan1 = new TimeSpan(5, 36, 5);
        var timespan2 = new TimeSpan(8, 36, 6);
        Console.WriteLine(timespan2 - timespan1);

        var birthday1 = new DateTime(2001, 4, 28);
        var birthday2 = new DateTime(1997, 4, 27);
        var difference = birthday1.Subtract(birthday2).Days / 365;
        Console.WriteLine($"The difference in years between {birthday1.ToShortDateString()} and {birthday2.ToShortDateString()} is {difference}");

        var today = DateTime.Now;
        Console.WriteLine(today);

        var todayOffset = new DateTimeOffset(today, TimeZoneInfo.Local.GetUtcOffset(today));
        Console.WriteLine(todayOffset);
        Console.WriteLine(today.Kind);
        var offsetTime = new DateTimeOffset(new DateTime(2022, 3, 16), new TimeSpan(3, 0, 0));
        Console.WriteLine(offsetTime.DateTime.Kind);
        Console.WriteLine(offsetTime.UtcDateTime.Kind);

        TimeZoneInfo timeZone = TimeZoneInfo.Local;
        Console.WriteLine(timeZone);

        Console.WriteLine(timeZone.IsDaylightSavingTime(today));
        DateTime date = new DateTime(2022, 5, 16, 2, 34, 30);
        Console.WriteLine(timeZone.IsDaylightSavingTime(date));

        Console.WriteLine($"Current culture is: {CultureInfo.CurrentCulture.Name}");
        var val = 123.45;
        Console.WriteLine($"Value in current culture is {val.ToString(CultureInfo.CurrentCulture)}");
        CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ro-RO");
        Console.WriteLine($"Value in Ro culture is {val.ToString(cultureInfo)}");

        CultureInfo us = CultureInfo.GetCultureInfo("us-US");
        Console.WriteLine(date.ToString(us));
        Console.WriteLine(date.ToString(cultureInfo));
        CultureInfo invariant = CultureInfo.InvariantCulture;
        Console.WriteLine(date.ToString(invariant));


    }
}