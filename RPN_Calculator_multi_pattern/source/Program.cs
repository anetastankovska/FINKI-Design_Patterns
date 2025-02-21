using source.Engine;

CalculatorEngine engine = new CalculatorEngine();

Console.WriteLine("Programmable RPN Calculator (Default mode)");
Console.WriteLine("Enter numbers and commands. Supported commands include:");
Console.WriteLine(" +, -, *, /, CHS, DROP, SWAP, SIN, COS, TAN, INV, RAD/DEG, UNDO, REDO, STO0 ... STO9, RCL0 ... RCL9");
Console.WriteLine("PROG to start program recording (end with END), and EXE to execute program.");
Console.WriteLine("CHMOD to switch the calculator mode between Defalt and Trigonometric");
Console.WriteLine("Type 'exit' to quit.");

while (true)
{
    Console.Write("> ");
    string input = Console.ReadLine();
    if (input == null)
        break;
    if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    // Split input by whitespace.
    string[] tokens = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

    engine.ProcessInput(input);
    engine.DisplayStack();
}
