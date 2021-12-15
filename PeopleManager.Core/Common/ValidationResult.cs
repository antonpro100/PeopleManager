namespace PeopleManager.Core.Common
{
    public class ValidationResult
    {
        public ValidationResult() { }
        public ValidationResult(string message) 
        {
            AddError(message);
        }

        public bool IsValid => !Errors.Any();
        public List<string> Errors { get; } = new List<string>();

        public void AddError(string errorMessage)
        {
            Errors.Add(errorMessage);
        }
    }
}
