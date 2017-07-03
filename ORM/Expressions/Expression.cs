using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Expressions
{
    abstract class Expression
    {
        public const string EQUAL = "=";
        public const string GREATER_THAN = ">";
        public const string LESS_THAN = "<";
        public const string GREATER_EQUAL = ">=";
        public const string LESS_EQUAL = "<=";
        public const string NOT_EQUAL = "<>";

        public const string AND = "AND";
        public const string OR = "OR";

        protected string op;

        public string Op { get => op; set => op = value; }
    }
}
