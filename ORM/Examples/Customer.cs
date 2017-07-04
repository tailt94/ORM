using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ORM.DataAttributes;
using ORM.DataAccess;

namespace ORM.Examples
{
    class Customer : IDataModel
    {
        [Column("ID")]
        private int id;

        [Column("Name")]
        private string name;
        
        [Column("Age")]
        private int age;

        [Column("City")]
        private string city;

        public Customer(int id, string name, int age, string city)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.city = city;
        }

        public Customer()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string City { get => city; set => city = value; }

        public override string ToString()
        {
            string r = id.ToString() + " - " + name + " - " + age.ToString() + " - " + city;
            return r;
        }
    }
}
