using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Expressions
{
    class ComplexExpression : Expression
    {
        private Expression exp1;
        private Expression exp2;

        public ComplexExpression(Expression exp1, Expression exp2, string op)
        {
            this.exp1 = exp1;
            this.exp2 = exp2;
            this.op = op;
        }

        public override string ToString()
        {
            return "(" + exp1.ToString() + " " + op + " " + exp2.ToString() + ")";
        }
    }
}
