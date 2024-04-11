using System.Text.RegularExpressions;

namespace Lab4
{
	internal partial class Menu
	{
		public static int Input(string header)
		{
			Console.WriteLine($"Введіть {header}:");
			return int.Parse(Integers().Matches(Console.ReadLine())[0].Value);
		}

		[GeneratedRegex(@"\d+")]
		private static partial Regex Integers();

		public static void Output(string header, params int[] numbers) => Console.WriteLine($"{header}: {string.Join(" ", numbers.Select((value, index) => (numbers.Length > 10 ? (index % 20 == 0 ? "\n" : "") + value.ToString().PadLeft(numbers[^1].ToString().Length) : value.ToString())))}");
	}
}