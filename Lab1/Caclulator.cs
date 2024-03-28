namespace Lab1
{
	internal static class Caclulator
	{
		public static List<string> Unite(List<string> a, List<string> b)
		{
			List<string> output = new(a);

			foreach (var i in b)
			{
				if (!a.Contains(i))
					output.Add(i);
			}

			return output;
		}

		public static List<string> Cross(List<string> a, List<string> b)
		{
			List<string> output = new(a);

			foreach (var i in a)
			{
				if (!b.Contains(i))
					output.Remove(i);
			}

			return output;
		}

		public static List<string> Subtract(List<string> a, List<string> b)
		{
			List<string> output = new(a);

			foreach (var i in b)
			{
				if (a.Contains(i))
					output.Remove(i);
			}

			return output;
		}

		public static List<string> SymmSubtract(List<string> a, List<string> b) => Subtract(Unite(a, b), Cross(a, b));

		public static bool CheckIfSub(List<string> a, List<string> b)
		{
			foreach (var i in a)
			{
                if (!b.Contains(i))
					return false;
			}

			return true;
		}

		public static bool CheckIfEqual(List<string> a, List<string> b) => CheckIfSub(b, a) && CheckIfSub(a, b);
	}
}