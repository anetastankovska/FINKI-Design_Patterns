using source.Commands;

namespace source.Managers
{
    // The ProgramRecorder class is responsible for recording a sequence of commands (a macro) and later executing that recorded program in one go.
    // The ProgramRecorder is an example of a macro command (or composite command) because it aggregates multiple commands to be executed as a unit.
    // It manages the sequence of operations and executes them in order. This is a form of command aggregation.
    public class ProgramRecorder
    {
        // List to store the recorded commands.
        private readonly List<ICommand> _recordedCommands = new List<ICommand>();

        // Indicates whether the recorder is currently recording a program.
        private bool _isRecording = false;

        // Maximum allowed steps in a recorded program.
        private const int MaxSteps = 20;

        // Gets a value indicating whether the recorder is currently recording.
        public bool IsRecording => _isRecording;

        // Starts recording a new program. This clears any previously recorded commands.
        public void StartRecording()
        {
            _recordedCommands.Clear();
            _isRecording = true;
            Console.WriteLine("Program recording started. Please record up to 20 commands.");
        }

        // Records a command if the recorder is in recording mode.
        /// <param name="command">The command to record.</param>
        public void RecordCommand(ICommand command)
        {
            if (!_isRecording)
                return;

            if (_recordedCommands.Count < MaxSteps)
            {
                _recordedCommands.Add(command);
            }
            else
            {
                Console.WriteLine("Reached maximum number of commands. Further commands will not be recorded.");
            }
        }

        // Stops the recording process. If the recorded program exceeds the maximum allowed steps, it discards the recorded commands.
        public void StopRecording()
        {
            _isRecording = false;
            if (_recordedCommands.Count > MaxSteps)
            {
                Console.WriteLine("Program exceeds maximum steps. Program recording discarded.");
                _recordedCommands.Clear();
            }
            else
            {
                Console.WriteLine($"Program recorded with {_recordedCommands.Count} command(s).");
            }
        }

        // Executes the stored program (macro) by running each recorded command in sequence.
        /// <param name="calc">The calculator on which to execute the commands.</param>
        public void ExecuteStoredProgram(Calculator calc)
        {
            if (_recordedCommands.Count == 0)
            {
                Console.WriteLine("No program recorded.");
                return;
            }
            Console.WriteLine("Executing stored program:");
            foreach (ICommand command in _recordedCommands)
            {
                // Execute each command using the calculator's command manager.
                calc.CommandManager.ExecuteCommand(command, calc);
            }
        }
    }
}
