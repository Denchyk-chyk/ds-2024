using System.Collections;
using Lab5.Enumerators;

namespace Lab5.Expressions.Types.Double
{
    internal class Conjunction(Expression left, Expression right, bool brackets) : Expression(Operator.Conjunction, brackets, left, right)
    {
        public override void Calculate(BitArray values) => Value = Left.Value && Right.Value;
    }
}