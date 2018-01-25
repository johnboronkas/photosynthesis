namespace photosynthesis.interpreter.commands
{
    public class CommandResponse
    {
        public CommandState State { get; private set; }
        public string FailureReason { get; private set; }

        public CommandResponse(CommandState state, string failureReason = "")
        {
            State = state;
            FailureReason = failureReason;
        }

        public override string ToString()
        {
            return State != CommandState.Failure ? "Command Successful" : "Error: " + FailureReason;
        }
    }
}
