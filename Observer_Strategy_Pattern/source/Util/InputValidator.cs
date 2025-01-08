namespace source.Util
{
    public static class InputValidator
    {
        public static string GetYesOrNoInput(string promptMessage)
        {
            while (true)
            {
                Console.WriteLine(promptMessage);
                var response = Console.ReadLine()?.ToLower();
                if (response == "y" || response == "n")
                {
                    return response;
                }
                Console.WriteLine("Invalid choice. Please enter 'y' to customize or 'n' to exit.");
            }
        }

        public static int GetValidChoice(string promptMessage, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(promptMessage);
                var input = Console.ReadLine();
                if (int.TryParse(input, out var choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"Invalid choice. Please enter a number between {min} and {max}.");
            }
        }

        public static decimal ValidateNumber(string promptMessage)
        {
            while (true)
            {
                Console.WriteLine(promptMessage);
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out var number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Must be a valid decimal number.");
            }
        }


    }
}

