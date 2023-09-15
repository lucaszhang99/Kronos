using System;
namespace Kronos.Controllers;


class DatetimeConversion
{
    public static decimal ConvertToDecimal(string? dateTime)
    {
        Console.WriteLine(dateTime);

        // Parse the duration string to extract hours and minutes.
        if (TryParseDuration(dateTime, out decimal durationInHours))
        {
            Console.WriteLine("Input Duration: " + dateTime);
            Console.WriteLine("Result Duration (hours): " + durationInHours);
            return durationInHours;
        }
        else
        {
            Console.WriteLine("Invalid duration format." + dateTime);
            return 0;
        }
    }

    static bool TryParseDuration(string input, out decimal durationInHours)
    {
        durationInHours = 0;

        // Split the input string into parts based on 'h' and 'm'.
        string[] parts = input.Split(new[] { 'h', 'm' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2 )
        {
            if ( decimal.TryParse(parts[0], out decimal hours) && decimal.TryParse(parts[1], out decimal minutes))
                {
                durationInHours = hours + (minutes / 60); // Calculate total duration in hours.
                return true;
            }
            
        }

        else if (parts.Length == 1 && decimal.TryParse(parts[0], out decimal hours))
        {
            durationInHours = hours;
            return true;
        }

        return false;
    }
}