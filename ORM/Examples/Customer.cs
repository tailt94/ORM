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
        [Column("id")]
        private int myId;

        [Column("name")]
        private string myName;

        public int MyId { get => myId; set => myId = value; }
        public string MyName { get => myName; set => myName = value; }

        public Customer(int id, string name)
        {
            this.myId = id;
            this.myName = name;
        }

        public Customer()
        {

        }

        public override string ToString()
        {
            string r = myId.ToString() + " - " + myName;
            return r;
        }
    }
}
