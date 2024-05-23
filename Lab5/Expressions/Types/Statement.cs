using System.Collections;
using Lab5.Enumerators;

namespace Lab5.Expressions.Types
{
    internal class Statement : Expression
    {
        private Variable _variable;

        public Statement(Variable variable) : base()
        {
            _variable = variable;
            Symbol = variable == Variable.P ? Operator.P : Operator.Q;
        }

        public override void Calculate(BitArray values) => Value = values[(int)_variable];
    }
}