using StructuralPatterns.ProxyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.FacadePattern
{
    public class BooksExport : IBooksExport
    {
        private string path = @"C:\Users\Catalina\Documents\Amdaris\Internship\StructuralPatterns\book_info.txt";

        public void ExportBooksInfo()
        {
            RetrieveDataProxy retrieveDataProxy = new RetrieveDataProxy();
            var books = retrieveDataProxy.GetBooks();
            foreach (var book in books)
            {
                WriteToFile(book.ToString(), path);
            }
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
