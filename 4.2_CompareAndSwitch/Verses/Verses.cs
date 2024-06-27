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
			switch (day) 
            {
    		case 1:
    			daySuffix ="st";
	             break;
    		case 2:
    			daySuffix ="nd";
	            break;
    		case 3:
    			daySuffix ="rd";
	            break;
            default:
            	daySuffix = "th";
                break;
		    }
		Console.WriteLine("On the " + day + daySuffix + " day of Christmas my true love gave to me");
	
		// TODO: Use a switch statement to control which lines get printed depending on the day
        switch(day)
        {
            case 12:
                Console.WriteLine("Twelve drummers drumming,");
                goto case 11;
            case 11:
                Console.WriteLine("Eleven pipers piping,");
                goto case 10;
            case 10:
                Console.WriteLine("Ten lords a leaping,");
                goto case 9;
            case 9:
                Console.WriteLine("Nine ladies dancing,");
                goto case 8;
            case 8:
                Console.WriteLine("Eight maids a milking,");
                goto case 7;
            case 7:
                Console.WriteLine("Seven swans a swimming,");
                goto case 6;
            case 6:
                Console.WriteLine("Six geese a laying,");
                goto case 5;
            case 5:
                Console.WriteLine("Five golden rings,");
                goto case 4;
            case 4:
                Console.WriteLine("Four calling birds,");
                goto case 3;
            case 3:
                Console.WriteLine("Three french hens,");
                goto case 2;
            case 2:
                Console.WriteLine("Two turtle doves, and");
                goto default;
            default:
                Console.WriteLine("A partridge in a pear tree.");
                break;
        }

    }
}
