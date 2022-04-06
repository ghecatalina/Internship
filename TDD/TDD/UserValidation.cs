using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class UserValidation
    {
        public static List<User> UserDatabase = new();

        public bool Register(User user)
        {
            if (user == null || user.Age < 16 || user.Password.Length < 8)
                return false;
            try
            {
                UserDatabase.Add(user);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public static List<User> GetUsers()
        {
            return UserDatabase;
        }
        
    }
}
