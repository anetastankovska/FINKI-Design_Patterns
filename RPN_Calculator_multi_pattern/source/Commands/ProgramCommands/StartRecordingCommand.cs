using source.Managers;

namespace source.Commands
{
    // Begins recording a macro in the ProgramRecorder.
    public class StartRecordingCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            // Optionally back up the calculator state if you want to allow undo.
            // But typically, starting/stopping a recording is not undone.
            calc.ProgramRecorder.StartRecording();
        }

        public override void Unexecute(Calculator calc)
        {
            // For simplicity, do nothing. 
            // If you wanted, you could "undo" the start by stopping recording, 
            // but that usually doesn't make sense for macro recording.
        }
    }
}
