namespace CM.Services.Contracts
{
    public class ActionSummary
    {
        public ActionSummary(bool isSuccesfull)
        {
            this.IsSuccessful = isSuccesfull;
        }

        public ActionSummary(bool isSuccesfull, string message)
            : this(isSuccesfull)
        {
            this.Message = message;
        }

        public string Message { get; }

        public bool IsSuccessful { get; }
    }
}