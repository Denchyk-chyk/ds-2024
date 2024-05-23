using System.Collections;
using Lab5.Enumerators;

namespace Lab5.Expressions.Types
{
    internal abstract class Expression
    {
        public bool Value { get; protected set; }
        public Expression Root { get; set; }
        public Expression Left { get; }
        public Expression Right { get; }

        protected bool Brackets { get; }
        protected Operator Symbol { get; set; }

        public Expression() { }

        public Expression(Operator symbol, bool brackets, Expression right) : this()
        {
			Symbol = symbol;
            Brackets = brackets;
            Right = right;
			right.Root = this;
        }

        public Expression(Operator symbol, bool brackets, Expression left, Expression right) : this(symbol, brackets, right)
        {
            Left = left;
            left.Root = this;
        }

        public int GetLayer()
        {
            int layer = 0;
            var root = Root;

            while (root != null)
            {
                layer++;
                root = root.Root;
            }

            return layer;
        }

        public abstract void Calculate(BitArray values);

		protected string PutInBrackets(string inside) => Brackets ? $"({inside})" : inside;
		
		public override string ToString() => PutInBrackets($"{(Left == null ? "" : Left)}{Parser.Operators[Symbol]}{(Right == null ? "" : Right)}");
	}
}