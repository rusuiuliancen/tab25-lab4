namespace WebApplication1.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public bool TryParseNumber(string value)
        {
            return int.TryParse(value, out _);
        }

    }
}
