namespace DoubleComp;
public class DoubleComparison
{
    static void Main(){
        const double TOLERANCE = 0.0000000000000001;
        double result = 1.0 - 0.9;
		double expected = 0.1;
		if(result == expected)
		{
			Console.WriteLine("They are equal!");
		}
		else
		{
			Console.WriteLine("They are not equal.");
		}
    }
}
