using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ORM.Libs;

namespace ORM.Expressions
{
    class SimpleExpression<L, R> : Expression
    {
        private L left;
        private R right;

        public L Left { get => left; set => left = value; }
        public R Right { get => right; set => right = value; }

        public SimpleExpression(L left, R right, string op)
        {
            this.left = left;
            this.right = right;
            this.op = op;
        }

        public override string ToString()
        {
            return left.ToString() + " " + op + " " + Util.FormatSqlValue(right);
        }
    }
}
