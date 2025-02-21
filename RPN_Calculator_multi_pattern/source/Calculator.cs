using source.Commands;
using source.Managers;
using source.Mementos;
using source.Modes;
using source.Utilities;
using System.Globalization;

namespace source
{
    /// Facade class managing the stack, registers, and token processing.
    /// Implements ICalculatorEngine for decoupling the UI from the core logic.
    public class Calculator
    {
        // Expose the command manager and program recorder for commands to use.
        public CommandManager CommandManager { get; } = new CommandManager();
        public ProgramRecorder ProgramRecorder { get; } = new ProgramRecorder();

        private readonly List<decimal> _stack = new List<decimal>();
        public decimal[] Registers { get; } = new decimal[10];

        // This property will serve for the UI.
        public IReadOnlyList<decimal> StackItems => _stack.AsReadOnly();

        // The current mode (strategy) for processing operators.
        // By default, it is set to DefaultMode.
        public ICalculatorMode Mode { get; set; } = new DefaultMode();

        // Property indicating the current angle unit ("RAD" or "DEG") for trigonometric operations.
        public string CurrentAngleUnit { get; set; } = "RAD";

        // Flag indicating whether inverse mode is active (affects trigonometric operations).
        public bool IsInverseMode { get; set; } = false;

        #region Memento

        // Creates a snapshot of the current state.
        public CalculatorMemento CreateMemento()
        {
            return new CalculatorMemento(_stack, Registers);
        }

        // Restores state from a snapshot.
        public void SetMemento(CalculatorMemento memento)
        {
            _stack.Clear();
            _stack.AddRange(memento.StackSnapshot);
            Array.Copy(memento.RegistersSnapshot, Registers, Registers.Length);
        }

        #endregion

        #region Stack Operations

        public void StackPush(decimal value)
        {
            _stack.Add(value);
        }

        public decimal StackPop()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException("Stack is empty.");
            decimal value = _stack[^1];
            _stack.RemoveAt(_stack.Count - 1);
            return value;
        }

        public decimal StackPeek()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException("Stack is empty.");
            return _stack[^1];
        }

        public int StackCount => _stack.Count;

        public void DisplayStack()
        {
            Console.WriteLine("Stack (top 4):");
            int count = _stack.Count;
            int start = Math.Max(0, count - 4);
            for (int i = count - 1; i >= start; i--)
            {
                Console.WriteLine(_stack[i]);
            }
        }

        #endregion

        #region Token Processing (Interpreter)

        // Process a single token from user input.
        public void ProcessToken(string token)
        {
            if (token.Equals("CHMOD", StringComparison.OrdinalIgnoreCase))
            {
                var currentMode = ToggleCalculatorMode();
                Console.WriteLine($"You changed the mode. The current mode is: {currentMode}");
                return;
            }
         
            // Check if we are recording a program.
            if (ProgramRecorder.IsRecording)
            {
                if (token.Equals("END", StringComparison.OrdinalIgnoreCase))
                {
                    ProgramRecorder.StopRecording();
                }
                else
                {
                    // Convert token into a command and record it.
                    ICommand command = ParseTokenToCommand(token);
                    if (command != null)
                    {
                        ProgramRecorder.RecordCommand(command);
                    }
                }
                return;
            }

            // Check for PROG command to start recording.
            if (token.Equals("PROG", StringComparison.OrdinalIgnoreCase))
            {
                ProgramRecorder.StartRecording();
                return;
            }

            // Check for EXE command to execute the stored program.
            if (token.Equals("EXE", StringComparison.OrdinalIgnoreCase))
            {
                CommandManager.ExecuteCommand(new ExecuteProgramCommand(), this);
                return;
            }

            // Check for UNDO / REDO commands.
            if (token.Equals("UNDO", StringComparison.OrdinalIgnoreCase))
            {
                CommandManager.Undo(this);
                return;
            }
            if (token.Equals("REDO", StringComparison.OrdinalIgnoreCase))
            {
                CommandManager.Redo(this);
                return;
            }

            // If token is an operator, let the current mode process it.
            if (IsOperator(token))
            {
                Mode.ProcessOperator(token, this);
                return;
            }

            // Otherwise, try to parse it as a number.
            if (decimal.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal number))
            {
                CommandManager.ExecuteCommand(new NumberCommand(number), this);
                return;
            }

            Console.WriteLine("Unknown token: " + token);
        }

        private bool IsOperator(string token)
        {
            // Assume tokens that are not numbers and not special commands are operators.
            string[] operators =
            {
                "+", "-", "*", "/", "CHS", "DROP", "SWAP",
                "SIN", "COS", "TAN", "ASIN", "ACOS", "ATAN",
                "INV", "RAD/DEG"
            };

            if (token.StartsWith("STO", StringComparison.OrdinalIgnoreCase) ||
                token.StartsWith("RCL", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return Array.Exists(operators, op => op.Equals(token, StringComparison.OrdinalIgnoreCase));
        }

        // Convert a token into a command (used in program recording).
        private ICommand ParseTokenToCommand(string token)
        {
            return TokenParser.ParseToken(token, this);
        }

        #endregion

        #region ICalculatorEngine Implementation
             
        public IReadOnlyList<decimal> GetStackContents()
        {
            // _stack is your private List<decimal>.
            // AsReadOnly() wraps it in a ReadOnlyCollection<decimal>.
            return _stack.AsReadOnly();
        }

        #endregion

        public string ToggleCalculatorMode()
        {
            if (Mode is DefaultMode defaultMode)
            {
                Mode = new TrigMode();
                return "Trigonometric mode";
            }

            Mode = new DefaultMode();
            return "Default mode";
        }
    }
}
