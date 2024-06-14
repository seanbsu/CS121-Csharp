// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
const int BASE =32;
const double CONVERSION_FACTOR = 5.0 / 9.0;

double farenheitTemp = 98.6;
double celciusTemp;
		
celciusTemp = (farenheitTemp-BASE) * CONVERSION_FACTOR;
Console.WriteLine("Celcius Temperature:" + celciusTemp);
Console.WriteLine("Fahrenheit Temperature: " +  farenheitTemp);