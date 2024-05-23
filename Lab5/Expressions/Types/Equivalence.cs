using Lab5.Enumerators;
using System.Collections;

namespace Lab5.Expressions.Types
{
    internal class Equivalence(Expression left, Expression right, bool brackets) : Expression(Operator.Equivalence, brackets, left, right)
    {
        public override void Calculate(BitArray values) => Value = Left.Value == Right.Value;
    }
}