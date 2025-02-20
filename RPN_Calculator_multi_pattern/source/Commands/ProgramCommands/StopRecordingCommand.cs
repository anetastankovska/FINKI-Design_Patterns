using source.Managers;

namespace source.Commands
{
    // Ends recording a macro in the ProgramRecorder.
    public class StopRecordingCommand : CalculatorCommand
    {
        public override void Execute(Calculator calc)
        {
            calc.ProgramRecorder.StopRecording();
        }

        public override void Unexecute(Calculator calc)
        {
            // Typically no undo for stopping a recording.
        }
    }
}
