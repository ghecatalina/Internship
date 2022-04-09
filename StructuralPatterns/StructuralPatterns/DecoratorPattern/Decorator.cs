using StructuralPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.DecoratorPattern
{
    public abstract class Decorator : DecItem
    {
        protected DecItem _decItem;
        public Decorator(DecItem decItem)
        {
            _decItem = decItem;
        }
        public override void Display()
        {
            _decItem.Display();
        }
    }
}
