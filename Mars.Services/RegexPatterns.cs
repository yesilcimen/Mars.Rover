namespace Mars.Services
{
    internal static class RegexPatterns
    {
        public const string PlateauSize = @"([1-9]\d*)\s([1-9]\d*)$";
        public const string RoverPosition = @"([1-9]\d*)\s([1-9]\d*)\s([NSWEnswe]{1})$";
        public const string Command = @"([LRMlrm]{1,})$";

    }
}
