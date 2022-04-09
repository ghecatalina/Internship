using StructuralPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.ProxyPattern
{
    public interface IRetrieveData
    {
        List<UserView> GetUsers();
        List<Book> GetBooks();
    }
}
