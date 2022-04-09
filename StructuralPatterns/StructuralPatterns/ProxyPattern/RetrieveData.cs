using StructuralPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.ProxyPattern
{
    public class RetrieveData : IRetrieveData
    {
        public List<Book> GetBooks()
        {
            Repository repo = new Repository();
            return repo.Books;
        }

        public List<UserView> GetUsers()
        {
            Repository repo = new Repository();
            return (List<UserView>)repo.Users.Select(user => new UserView
            {
                Username = user.Username,
                Email = user.Email,
            });
        }
    }
}
