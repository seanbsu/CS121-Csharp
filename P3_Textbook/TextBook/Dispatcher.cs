namespace TextBook;
class Dispatcher{
static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify an entry point: 'PostTester', 'Driver', or 'AnotherTester'.");
                return;
            }
            int status = 0;
            switch (args[0].ToLower())
            {
                
                case "posttester":
                     status = PostUnitTester.Run();
                    break;
                case "driver":
                    TextBookDriver.Run();
                    break;
                case "textbooktester":
                     status = TextBookUnitTester.Run();
                    break;
                default:
                    Console.WriteLine("Invalid entry point specified. Use 'PostTester', 'Driver', or 'TextBookTester'.");
                    break;
            }
        }
   }