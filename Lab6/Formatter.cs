using Lab5;

namespace Lab6
{
	internal class Formatter
	{
		private List<(bool[] key, bool value)> _function;

		public Formatter(bool[] function)
		{
			_function = [];
			var counter = new BinaryCounter(function.Length);
			foreach (bool[] item in counter) _function.Add((item, function[counter.Index]));
		}

		private bool[][] CreateForm(bool value) => _function.Where(e => e.value == value).Select(e => e.key.Select(i => i == value).ToArray()).ToArray();

		public bool[][] CreateDisjunctiveForm() => CreateForm(true);

		public bool[][] CreateConjunctiveForm() => CreateForm(false);
	}
}