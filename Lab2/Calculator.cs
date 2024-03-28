using System.Collections;

namespace Lab2
{
	internal class Calculator
	{
		public List<string> U;
		public BitArray A { get; private set; }
		public BitArray B { get; private set; }

		public Calculator(List<string> u, List<string> a, List<string> b)
		{
			U = u;
			A = ToRaw(a);
			B = ToRaw(b);
		}

		private BitArray ToRaw(List<string> set)
		{
			var output = new BitArray(U.Count);

			for (int i = 0; i < U.Count; i++)
				output[i] = set.Contains(U[i]);

			return output;
		}

		public List<string> ToSet(BitArray raw)
		{
			List<string> output = [];

			for (int i = 0; i < raw.Count; i++)
			{
				if (raw[i])
					output.Add(U[i]);
			}

			return output;
		}

		public List<bool> Operate(BitArray a, BitArray b, Operation operation)
		{
			List<bool> output = new(a.Count);

			for (int i = 0; i < a.Count; i++)
				output.Add(operation(a[i], b[i]));

			return output;
		}

		public List<bool> Unite() => Operate(A, B, (a, b) => a || b);

		public List<bool> Cross() => Operate(A, B, (a, b) => a && b);

		public List<bool> Subtract(BitArray a, BitArray b) => Operate(a, b, (a, b) => a && !b);

		public List<bool> SymmSubtract() => Operate(A, B, (a, b) => a != b);

		public List<string> CartesianProduct(List<bool> a, List<bool> b)
		{
			List<string> product = [];

			for (int i = 0; i < U.Count; i++)
			{
				for (int j = 0; j < U.Count; j++)
				{
					if (a[i] && b[j])
						product.Add($"({U[i]}, {U[j]})");
				}
			}

			return product;
		}
	}

	internal delegate bool Operation(bool a, bool b);
}