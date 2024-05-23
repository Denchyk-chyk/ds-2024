using System.Collections;
using Lab5.Enumerators;
using Lab5.Expressions.Types;

namespace Lab5.Expressions
{
    internal class Disjunction(Expression left, Expression right, bool brackets) : Expression(Operator.Disjunction, brackets, left, right)
    {
        public override void Calculate(BitArray values) => Value = Left.Value || Right.Value;
    }
}