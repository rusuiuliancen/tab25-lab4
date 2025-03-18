using System.Collections.Generic;
using System.Linq;

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

    public class MyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }

    public static class MyClassList
    {
        public static List<MyClass> Objects = new List<MyClass>
        {
            new MyClass { Id = 1, Name = "John", Age = 30, Address = "123 Street", Email = "john@example.com" },
            new MyClass { Id = 2, Name = "Jane", Age = 25, Address = "456 Avenue", Email = "jane@example.com" },
            new MyClass { Id = 3, Name = "Bob", Age = 35, Address = "789 Boulevard", Email = "bob@example.com" },
            new MyClass { Id = 4, Name = "Alice", Age = 28, Address = "101 Road", Email = "alice@example.com" },
            new MyClass { Id = 5, Name = "Tom", Age = 40, Address = "202 Lane", Email = "tom@example.com" }
        };
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

        public IEnumerable<MyClass> GetObjectsWhereClause(string value)
        {
            // Method-based query
            return MyClassList.Objects.Where(obj => obj.Name.Contains(value));
        }

        public IEnumerable<string> GetPropertyValues()
        {
            // Query expression
            var query = from obj in MyClassList.Objects
                        select obj.Name;
            return query;
        }

        public int CountElements()
        {
            // Method-based query
            return MyClassList.Objects.Count();
        }

        public IEnumerable<string> WhereJoin()
        {
            // Query expression with Where and Join
            var query = from obj in MyClassList.Objects
                        where obj.Age > 30
                        join user in users on obj.Name equals user.Username
                        select obj.Name;
            return query;
        }
    }
}
