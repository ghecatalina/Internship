using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Zoo
    {
        public string Name { get; set; }
        public List<string> Employees { get; set; }

        public override string ToString()
        {
            string res = this.Name;
            foreach(var employee in Employees)
            {
                res += " " + employee;
            }
            return res;
        }
    }
}
