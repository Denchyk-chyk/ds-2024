using Lab5.Enumerators;
using Lab5.Expressions;
using Lab5.Expressions.Types;
using Lab5.Expressions.Types.Double;

namespace Lab5
{
    internal class Parser
	{
		public static Dictionary<Operator, char> Operators = [];

		private int[] _sorted;
		private bool[] _brackets;
		private string _text;
		private static Dictionary<char, int> _priority = [];
		private Dictionary<char, Func<(int self, int first, int last), Expression>> _expressions = [];

		public Parser(string text)
		{
			_text = text;

			_expressions[Operators[Operator.Conjunction]] = (location) => new Conjunction(Get(location.first, location.self), Get(location.self + 1, location.last), _brackets[location.self]);
			_expressions[Operators[Operator.Disjunction]] = (location) => new Disjunction(Get(location.first, location.self), Get(location.self + 1, location.last), _brackets[location.self]);
			_expressions[Operators[Operator.Implication]] = (location) => new Implication(Get(location.first, location.self), Get(location.self + 1, location.last), _brackets[location.self]);
			_expressions[Operators[Operator.Equivalence]] = (location) => new Equivalence(Get(location.first, location.self), Get(location.self + 1, location.last), _brackets[location.self]);
			_expressions[Operators[Operator.Objection]] = (location) => new Objection(Get(location.self + 1, location.last));
			_expressions[Operators[Operator.P]] = (location) => new Statement(Variable.P);
			_expressions[Operators[Operator.Q]] = (location) => new Statement(Variable.Q);
		}

		static Parser()
		{
			Operators[Operator.Conjunction] = '\u2227';
			Operators[Operator.Disjunction] = '\u2228';
			Operators[Operator.Implication] = '\u2192';
			Operators[Operator.Equivalence] = '\u007E';
			Operators[Operator.Objection] = '\u00AC';
			Operators[Operator.P] = 'p';
			Operators[Operator.Q] = 'q';
			Operators[Operator.OpenBracket] = '(';
			Operators[Operator.CloseBracket] = ')';

			_priority[Operators[Operator.OpenBracket]] = _priority[Operators[Operator.CloseBracket]] = short.MinValue;
			_priority[Operators[Operator.P]] = _priority[Operators[Operator.Q]] = 0;
			_priority[Operators[Operator.Objection]] = 1;
			_priority[Operators[Operator.Conjunction]] = 2;
			_priority[Operators[Operator.Disjunction]] = 3;
			_priority[Operators[Operator.Implication]] = 4;
			_priority[Operators[Operator.Equivalence]] = 5;
		}

		public ExpressionTree Get()
		{
			_sorted = _text.Select(item => _priority[item]).ToArray();

			for (int i = 0, remove = 0; i < _text.Length; i++)
			{
				if (_text[i] == Operators[Operator.OpenBracket]) remove += _priority.Count;
				else if (_text[i] == Operators[Operator.CloseBracket]) remove -= _priority.Count;

				_sorted[i] -= remove;
			}

			_sorted = _sorted.Select((value, index) => value * _text.Length + index).ToArray();
			_brackets = Enumerable.Range(0, _text.Length).Select(item => CheckBrackets(item)).ToArray();
			return new ExpressionTree(Get(0, _text.Length));
		}

		private bool CheckBrackets(int index)
		{
			int open = index, close = index, openCounter = 0, closeCounter = 0;

			while (openCounter < 1)
			{
				open--;
				if (open < 0) return false;

				if (_text[open] == Operators[Operator.OpenBracket]) openCounter++;
				else if (_text[open] == Operators[Operator.CloseBracket]) openCounter--;
			}

			open++;

			while (closeCounter < 1)
			{
				close++;
				if (close >= _text.Length) return false;

				if (_text[close] == Operators[Operator.CloseBracket]) closeCounter++;
				else if (_text[close] == Operators[Operator.OpenBracket]) closeCounter--;
			}

			return GetLast(open, close) == index;
		}

		private int GetLast(int first, int last)
		{
			List<int> queue = Enumerable.Range(first, last - first).ToList();
			queue.Sort((x, y) => _sorted[y] - _sorted[x]);
			return queue[0];
		}

		private Expression Get(int first, int last)
		{
			int index = GetLast(first, last);
			return _expressions[_text[index]]((index, first, last));
		}
	}
}