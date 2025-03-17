namespace WebApplication1.Services.Delegate
{
    public interface IDelegateService
    {
        string Greeting(string value, Func<string, string> callback);

        string UpperValue(string value);
    }
}
