using source.Models.Implementations;
using source.Models.Interfaces;
using source.Services.Operations;

namespace source.Util
{
    public static class RegisterHelper
    {
        public static void SetRegisterValue(Register register, string name)
        {
            decimal value = InputValidator.ValidateNumber(">> value=");
            register.Value = value;
        }

        public static void AddObserver(Register regA, Register regB)
        {
            Console.Write(">> Set New Observer (A|B) (+|-|*|/) <num>): ");
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length != 2)
            {
                Console.WriteLine("Invalid input format.");
                return;
            }

            Register register = input[0].ToLower() == "a" ? regA : regB;
            char operation = input[1][0];
            decimal operand = decimal.Parse(input[1].Substring(1));

            IOperation op = operation switch
            {
                '+' => new AddOperation(),
                '-' => new SubtractOperation(),
                '*' => new MultiplyOperation(),
                '/' => new DivideOperation(),
                _ => throw new ArgumentException("Invalid Operation")
            };

            register.Attach(new Observer(op, operand, Register.RegisteredObservers));
        }

        public static void RemoveObserver(Register regA, Register regB)
        {
            Console.Write(">> Remove Observer (#): ");
            if (int.TryParse(Console.ReadLine(), out int observerIndex))
            {
                List<IObserver> allObservers = new List<IObserver>();
                allObservers.AddRange(regA.GetObservers());
                allObservers.AddRange(regB.GetObservers());

                if (regA.Observers.Any(x => x.ID == observerIndex))
                {
                    regA.Detach(regA.Observers.First(x => x.ID == observerIndex));
                }
                else if (regB.Observers.Any(y => y.ID == observerIndex))
                {
                    regB.Detach(regB.Observers.First(y => y.ID == observerIndex));
                }
                else
                {
                    Console.WriteLine("Invalid observer index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        private static void DisplayRemainingObservers(Register regA, Register regB)
        {
            List<IObserver> allObservers = new List<IObserver>();
            allObservers.AddRange(regA.GetObservers());
            allObservers.AddRange(regB.GetObservers());

            for (int i = 0; i < allObservers.Count; i++)
            {
                Observer observer = allObservers[i] as Observer;
                if (observer != null)
                {
                    decimal result = observer.GetLastResult();
                    Console.WriteLine($"< observer #{observer.ID} is {result}");
                }
            }
        }

    }
}
