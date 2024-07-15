using Lab5;

namespace Lab6
{
	internal class Analyzer()
	{
		public static bool[] Analyze(bool[] function, out bool[] linear) => [!function[0], function[^1], 
			Enumerable.Range(0, function.Length / 2).Select(i => function[i] != function[^(i + 1)]).Aggregate((x, y) => x && y), 
			AnalyzeLinearity(function, out linear)];

		private static List<bool[]> GetValues(int count)
		{
			List<bool[]> values = [];
			var variablesCounter = new BinaryCounter(count);
			foreach (bool[] item in variablesCounter) values.Add(item);
			return values;
		}

		private static bool AnalyzeLinearity(bool[] function, out bool[] linear)
		{
			var variables = GetValues(function.Length);
			var constants = GetValues(function.Length + 1);

			linear = new bool[function.Length];

			foreach (var set in constants)
			{
				bool result = false;

				for (int i = 0; i < variables.Count; i++)
				{
					bool value = set[0];
					for (int j = 1; j < set.Length; j++) 
						value = value != (set[j] && variables[i][j - 1]);

					result = value != function[i];
					if (!result) break;
				}

				if (result)
				{
					linear = set;
					return true;
				}
			}

			return false;
		}
	}
}