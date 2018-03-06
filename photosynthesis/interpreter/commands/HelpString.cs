namespace photosynthesis.interpreter.commands
{
    public static class HelpString
    {
        public static string Create(string commandName, string parameters, string description)
        {
            return string.Format("{0}{1}\n\t{2}",
                commandName,
                (parameters.Length > 0) ? " " + parameters : "",
                description);
        }   
    }
}