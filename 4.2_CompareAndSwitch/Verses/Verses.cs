using System.Data;

namespace Verses;
public class Verses
{
    static void Main()
    {
        Console.WriteLine("Which day is it (1 - 12)? ");
        int day = int.Parse(Console.ReadLine());

        // TODO: Use a switch statement to set the appropriate suffix for the day
		String daySuffix = "st";
		
		Console.WriteLine("On the " + day + daySuffix + " day of Christmas my true love gave to me");
	
		// TODO: Use a switch statement to control which lines get printed depending on the day
		Console.WriteLine("Twelve drummers drumming,");
		Console.WriteLine("Eleven pipers piping,");
		Console.WriteLine("Ten lords a leaping,");
		Console.WriteLine("Nine ladies dancing,");
		Console.WriteLine("Eight maids a milking,");
		Console.WriteLine("Seven swans a swimming,");
		Console.WriteLine("Six geese a laying,");
		Console.WriteLine("Five golden rings,");
		Console.WriteLine("Four calling birds,");
		Console.WriteLine("Three french hens,");
		Console.WriteLine("Two turtle doves, and");
		Console.WriteLine("A partridge in a pear tree.");
    }
}
