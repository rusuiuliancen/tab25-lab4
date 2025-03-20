namespace WebApplication1.Services.Linq
{
    public class User
    {
        public User(string name, string level)
        {
            Username = name;
            SecurityLevel = level;
        }

        public string Username { get; set; }
        public string SecurityLevel { get; set; }
    }

    public class LinqService : ILinqService
    {
        //
        public int UserSecurityLevelCount(string value)
        {
            return UserStorage.Users.Count(student => student.SecurityLevel == value);
        }
    }
}
