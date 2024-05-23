using System.Collections;
using Lab5.Enumerators;

namespace Lab5
{
    internal static class Menu
	{
		private static Dictionary<string, string> _operands = [];

		public static void Playback()
		{
			Console.WriteLine("Вираз:");
			string text = Console.ReadLine();
			foreach ((var key, var value) in _operands) text = text.Replace(key, value);
			Console.WriteLine(text);
			
			var table = new Parser(text).Get().ToTable();
			table.RemoveAll(x => x[0] == Parser.Operators[Operator.P].ToString() || x[0] == Parser.Operators[Operator.Q].ToString());
			table.Insert(0, [Parser.Operators[Operator.Q].ToString(), "0", "1", "0", "1"]);
			table.Insert(0, [Parser.Operators[Operator.P].ToString(), "0", "0", "1", "1"]);

			for (int y = 0; y < table[0].Length; y++) Console.WriteLine(string.Join(" ", table.Select(item => item[y])));
		}

		public static string AsText(this BitArray row) => string.Join(' ', Enumerable.Range(0, row.Length).Select(i => row[i] ? '1' : '0'));

		static Menu()
		{
			_operands["&"] = _operands["*"] = _operands["^"] = Parser.Operators[Operator.Conjunction].ToString();
			_operands["|"] = _operands["+"] = Parser.Operators[Operator.Disjunction].ToString();
			_operands["=>"] = _operands["->"] = Parser.Operators[Operator.Implication].ToString();
			_operands["="] = Parser.Operators[Operator.Equivalence].ToString();
			_operands["!"] = _operands["-"] = Parser.Operators[Operator.Objection].ToString();
		}
	}
}