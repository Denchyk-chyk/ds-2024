using System.Text.RegularExpressions;

namespace Lab1
{
	internal static class Menu
	{
		public static List<string> Input(string text)
		{
			Console.WriteLine($"{text}:");
			var chars = Console.ReadLine().ToCharArray();
			for (int i = 0; i < chars.Length; i++)
			{
				if (chars[i] == ',')
					chars[i] = ' ';
			}

			return Regex.Replace(new string(chars), @"\s+", " ").Split(' ').ToList();
		}

		public static void Output(string text, List<string> set) => Console.WriteLine($"{text} | {string.Join(", ", set)}");
	}
}