namespace WebApplication1.Services.Linq
{
    public static class UserStorage
    {
        public static List<User> Users = new List<User>
        {
            new User("John Doe", "L1"),
            new User("Dan Smith", "L2"),
            new User("Peter Parker", "L2"),
        };
    }
}
