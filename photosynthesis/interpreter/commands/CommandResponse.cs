namespace photosynthesis.interpreter.commands
{
    public class CommandResponse
    {
        public bool IsSuccessful { get; private set; }
        public string FailureReason { get; private set; }

        public CommandResponse(bool isSuccessful, string failureReason = "")
        {
            IsSuccessful = isSuccessful;
            FailureReason = failureReason;
        }

        public override string ToString()
        {
            return IsSuccessful ? "Command Successful" : "Error: " + FailureReason;
        }
    }
}
