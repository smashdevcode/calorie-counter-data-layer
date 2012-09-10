using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Data;
using CalorieCounter.Data.Entities;

namespace CalorieCounter.TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository(true);

            repository.AddUser(new User()
            {
                Username = "user1",
                Name = "John Smith",
                Email = "john@smith.com"
            });
            repository.AddUser(new User()
            {
                Username = "user2",
                Name = "Jane Doe",
                Email = "jane@doe.com"
            });

            var users = repository.GetUsers();
            users.ForEach(u => Console.WriteLine("UserID: {0}", u.UserID));
            Console.WriteLine("Number of Users: {0}", users.Count);

            Console.WriteLine("Press Enter to continue");
            Console.Read();
        }
    }
}
