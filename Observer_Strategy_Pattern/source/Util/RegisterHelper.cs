using source.Models.Implementations;
using source.Models.Interfaces;
using source.Services.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Util
{
    public static class RegisterHelper
    {
        public static void SetRegisterValue(Register register, string name)
        {
            Console.Write($">> value for Register {name}=");
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                register.Value = value;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a decimal value.");
            }
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
                _ => throw new ArgumentException("Invalid operation")
            };

            register.Attach(new Observer(op, operand));
        }

        public static void RemoveObserver(Register regA, Register regB)
        {
            Console.Write(">> Remove Observer (#): ");
            if (int.TryParse(Console.ReadLine(), out int observerIndex))
            {
                List<IObserver> allObservers = new List<IObserver>();
                allObservers.AddRange(regA.GetObservers());
                allObservers.AddRange(regB.GetObservers());

                if (observerIndex >= 0 && observerIndex < allObservers.Count)
                {
                    IObserver observerToRemove = allObservers[observerIndex];
                    if (regA.GetObservers().Contains(observerToRemove))
                    {
                        regA.Detach(observerToRemove);
                    }
                    else if (regB.GetObservers().Contains(observerToRemove))
                    {
                        regB.Detach(observerToRemove);
                    }

                    Console.WriteLine($"Observer #{observerIndex} removed.");

                    // Display remaining observers
                    DisplayRemainingObservers(regA, regB);
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
                    Console.WriteLine($"< observer #{i} is {result}");
                }
            }
        }

    }

}
