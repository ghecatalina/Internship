using StructuralPatterns.DecoratorPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Models
{
    public class Book : DecItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public IEnumerable<Review> Reviews { get; set; }

        public override void Display()
        {
            Console.WriteLine($"{Title}: {Author} -> physical");
        }

        public override string ToString()
        {
            return $"~~Book {Title} written by {Author} has the following details:\n{Description}\n";
        }
    }
}
