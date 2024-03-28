using System.Collections;

namespace Lab3
{
	internal class Menu
	{
		public static BitArray Input(string header)
		{
			Console.WriteLine($"{header}:");
			var line = ReadLine();
			var matrix = new BitArray(line.Length * line.Length);

			for (int i = 0, size = line.Length; true; i++)
			{
				for (int j = 0; j < line.Length; j++)
					matrix.Set(i * line.Length + j, line[j] == '1');

				if (i == size - 1) break;
				line = ReadLine();
			}

			return matrix;
		}

		private static char[] ReadLine() => Console.ReadLine().Where(c => c == '1' || c == '0').ToArray();

		public static void Output(Kind kind, params string[] variants)
		{
			Console.WriteLine($"Відношення {variants[(int)kind]}");
		}
	}
}