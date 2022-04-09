using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.FacadePattern
{
    public class BooksExportFacade
    {
        private IBooksExport _BooksExport;
        public BooksExportFacade()
        {
            _BooksExport = new BooksExport();
        }

        public void ExportBooksInfo()
        {
            _BooksExport.ExportBooksInfo();
        }
    }
}
