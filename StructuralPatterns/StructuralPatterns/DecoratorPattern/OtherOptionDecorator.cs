using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.DecoratorPattern
{
    public class OtherOptionDecorator : Decorator
    {
        public OtherOptionDecorator(DecItem decItem) : base(decItem)
        {

        }

        public void ChangeOption(string option)
        {
            _decItem.OtherOption = option;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Added {_decItem.OtherOption.ToUpper()} option\n");
        }
    }
}
