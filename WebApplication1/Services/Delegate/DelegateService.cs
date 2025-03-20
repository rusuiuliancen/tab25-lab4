namespace WebApplication1.Services.Delegate
{
    public class DelegateService : IDelegateService
    {
        public string Greeting(string value, Func<string, string> callback)
        {
            return $"Greetings, {callback(value)}";
        }

        public string UpperValue(string value)
        {
            return value.ToUpper();
        }

        public string LowerValue(string value)
        {
            return value.ToLower();
        }
    }
}
