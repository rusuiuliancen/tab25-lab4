namespace WebApplication1.Services.Linq
{
    public interface ILinqService
    {
        int UserSecurityLevelCount(string value);
        IEnumerable<MyClass> GetObjectsWhereClause(string value);
        IEnumerable<string> GetPropertyValues();
        int CountElements();
        IEnumerable<string> WhereJoin();
    }
}
