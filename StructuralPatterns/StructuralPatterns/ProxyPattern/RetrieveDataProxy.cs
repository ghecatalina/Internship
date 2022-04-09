using StructuralPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.ProxyPattern
{
    public class RetrieveDataProxy : IRetrieveData
    {
        private RetrieveData retrieveData = new RetrieveData();
        public List<Book> GetBooks()
        {
            return retrieveData.GetBooks();
        }

        public List<UserView> GetUsers()
        {
            return retrieveData.GetUsers();
        }
    }
}
