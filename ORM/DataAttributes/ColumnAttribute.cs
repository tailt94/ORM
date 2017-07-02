using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORM.DataAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class ColumnAttribute : Attribute
    {
        public string Name { get; private set; }

        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
