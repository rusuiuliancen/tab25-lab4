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
        public List<User> users = new List<User>()
        {
            new User("John Doe", "L1"),
            new User("Dan Smith", "L2"),
            new User("Peter Parker", "L2"),
        };

        public int UserSecurityLevelCount(string value)
        {
            return users.Count(student => student.SecurityLevel == value);
        }
    }
}
