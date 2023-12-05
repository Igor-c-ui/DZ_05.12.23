using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov14
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DeveloperInfoAttribute:Attribute
    {
        public string Name { get; }
        public string Datetime { get; }

        public DeveloperInfoAttribute(string name, string datetime)
        {
            Name = name;
            Datetime = datetime;
        }
    }
}
