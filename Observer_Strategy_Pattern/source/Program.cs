using source.Models.Implementations;
using source.Util;

Register regA = new Register();
Register regB = new Register();

while (true)
{
    Console.Write("Set_val[A] Set_val[B] [+]AddObserver [-]RemoveObserver e[X]it > ");
    string input = Console.ReadLine();

    switch (input.ToLower())
    {
        case "a":
            RegisterHelper.SetRegisterValue(regA, "A");
            break;
        case "b":
            RegisterHelper.SetRegisterValue(regB, "B");
            break;
        case "+":
            RegisterHelper.AddObserver(regA, regB);
            break;
        case "-":
            RegisterHelper.RemoveObserver(regA, regB);
            break;
        case "x":
            return;
        default:
            Console.WriteLine("Invalid input. Please try again.");
            break;
    }
}
