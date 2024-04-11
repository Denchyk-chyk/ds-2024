namespace Lab4
{
	internal class Soluction
	{
		public static int GreatestCommonDiviser(int a, int b)
		{
			(a, b) = (Math.Max(a, b), Math.Min(a, b));
			
            while (b > 0)
			{
				a %= b;
				(a, b) = (b, a);
			}

			return a;
		}

		public static int LeastCommonMultiple(int a, int b) => a * b / GreatestCommonDiviser(a, b);

		public static int[] GetPrimeFactors(int number)
		{
			List<int> factors = [];

			while (number > 1)
			{
				for (int i = 2; i <= number; i++)
				{
					if (number % i == 0)
					{
						factors.Add(i);
						number /= i;
						break;
					}
				}
			}

			return [.. factors];
		}

		public static int[] FindDivisors(int number)
		{
			List<int> divisers = [];

			for (int i = 1; i <= number; i++)
				if (number % i == 0) divisers.Add(i);

			return [.. divisers];
		}

		public static int[] FindCongruentNumbers(int a, int b)
		{
			List<int> numbers = [];

			for (int i = 2, end = Math.Min(a, b); i <= end; i++)
				if (a % i == b % i) numbers.Add(i);

			return [.. numbers];
		}

		public static int[] GetPrimeNumbers(int a, int b)
		{
			var numbers = new bool[Math.Max(a, b) + 1];
			numbers[0] = numbers[1] = true;

			for (int i = 2; i < numbers.Length; i++)
			{
				if (!numbers[i])
				{
					for (int j = 2; j < i; j++)
					{
						if (i % j == 0)
						{
							numbers[j] = true;
							break;
						}
					}

					for (int j = i * 2; j < numbers.Length; j += i) numbers[j] = true;
				}
			}

			return numbers.Select((value, index) => value ? -1 : index).Where(item => item >= 0).ToArray();
		}
	}
}