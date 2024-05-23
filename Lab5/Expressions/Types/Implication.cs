using System.Collections;
using Lab5.Enumerators;

namespace Lab5.Expressions.Types
{
    internal class Implication(Expression left, Expression right, bool brackets) : Expression(Operator.Implication, brackets, left, right)
    {
        public override void Calculate(BitArray values) => Value = Left.Value || !Right.Value;
    }
}