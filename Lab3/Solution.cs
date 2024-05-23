using System.Collections;

namespace Lab3
{
	internal class Solution
	{
		public static Kind CheckReflexivity(BitArray matrix)
		{
			var calc = new Calculator(matrix, (m, n) => m[n[0]]);

			for (int i = 0, size = (int)Math.Sqrt(matrix.Length); i < matrix.Length; i += size + 1)
				calc.Process(i);
			
			return calc.Solve();
		}

		public static Kind CheckSymmetry(BitArray matrix)
		{
			var calc = new Calculator(matrix, (m, n) => m[n[1] * n[2] + n[0]] == m[n[0] * n[2] + n[1]]);

			for (int y = 0, size = (int)Math.Sqrt(matrix.Length); y < size; y++)
			{
				for (int x = y + 1; x < size; x++)
					calc.Process(x, y, size);
			}

			return calc.Solve();
		}

		internal class Calculator(BitArray row, Inspector inspector)
		{
			private int _zero, _one;

			public void Process(params int[] numbers)
			{
				if (inspector(row, numbers)) _one++;
				else _zero++;
			}

			public Kind Solve() => _zero == 0 ? Kind.Orinary : _one == 0 ? Kind.Anti : Kind.None;
		}

		internal delegate bool Inspector(BitArray row, params int[] numbers);

		public static Kind CheckTransitivity(BitArray matrix)
		{
			for (int i = 0, size = (int)Math.Sqrt(matrix.Length); i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					for (int k = 0; k < size; k++)
					{
						if (matrix[i * size + j] && matrix[j * size + k] && !matrix[i * size + k])
							return Kind.None;
					}
				}
			}

			return Kind.Orinary;
		}
	}

	internal enum Kind
	{
		None, Orinary, Anti
	}
}