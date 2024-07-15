using System.Text.RegularExpressions;

namespace Lab6
{
	internal class Menu
	{
		private string[] _variables;

		public Menu()
		{
			Console.WriteLine("Назви змінних:");
			_variables = Regex.Replace(Console.ReadLine(), @"\s+", " ").Split(' ');
		}

		public bool[] InputFunction()
		{
			Console.WriteLine("Значення функції:");
			return Console.ReadLine().Where(char.IsDigit).Select(item => item != '0').ToArray();
		}

		public void Output(bool[] values, string[] meaning) =>
			Console.WriteLine(string.Join("\n", Enumerable.Range(0, values.Length).Where(i => values[i]).Select(i => meaning[i])));

		public void Output(bool[] linear) => Console.WriteLine($"{(linear[0] ? 1 : 0)} ⊕ " + string.Join(" ⊕ ", _variables.Select((v, i) => (linear[i + 1] ? "" : "¬") + v)));

		public void Output(bool[][] value, char[] symbols, string title) => 
			Console.WriteLine($"{title}: " + string.Join($" {symbols[0]} ", value.Select(e => $"({string.Join($" {symbols[1]} ", e.Select((v, i) => (v ? "" : '¬') + _variables[i]))})")));
	}
}