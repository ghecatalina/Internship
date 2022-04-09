using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.DecoratorPattern
{
    public abstract class DecItem
    {
        public string OtherOption { get; set; }
        public abstract void Display();
    }
}
