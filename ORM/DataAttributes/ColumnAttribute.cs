using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORM.DataAttributes
{
    /// <summary>
    /// Attribute to specify column name of a table
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    class ColumnAttribute : Attribute
    {
        public string Name { get; private set; }

        public ColumnAttribute(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
