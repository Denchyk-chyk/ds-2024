using System.Collections;
using Lab5.Enumerators;
using Lab5.Expressions.Types;

namespace Lab5
{
    internal class Objection(Expression statement) : Expression(Operator.Objection, false, statement)
	{
		public override void Calculate(BitArray values) => Value = !Right.Value;
	}
}