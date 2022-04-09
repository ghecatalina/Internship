using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static void Auth(User user, string path)
        {
            if (Validation(user, path))
            {
                Console.WriteLine("Login...");
                Console.WriteLine($"Welcome back {user.Username}");
            }
            else
            {
                WriteToFile($"{user.Username}:{user.Password}", path);
                Console.WriteLine("Register...");
                Console.WriteLine($"Welcome {user.Username}");
            }
        }

        public static bool Validation(User user, string path)
        {
            List<User> users = ReadFile(path);
            return users.Any(u => u.Username == user.Username && u.Password == user.Password);
        }

        public static List<User> ReadFile(string path)
        {
            List<User> users = new List<User>();
            using (StreamReader sr = new StreamReader(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    int idx = s.IndexOf(':');
                    var user = new User { Username = s.Substring(0, idx), Password = s.Substring(idx + 1) };
                    users.Add(user);
                }
            }
            return users;
        }

        public static void WriteToFile(string line, string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(line);
            }
        }
    }
}
