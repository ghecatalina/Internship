using Streams;

string path = @"C:\Users\Catalina\Documents\Amdaris\Internship\Streams\db.txt";
User user = new User { Username = "ana.maria", Password = "1234" };
User.Auth(user, path);

