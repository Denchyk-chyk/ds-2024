using System.Collections;

namespace Lab5
{
	public class BinaryCounter : IEnumerable<bool[]>, IEnumerator<bool[]>
	{
		public int Size { get; private set; }
		public int Index { get; private set; }
		public bool[] Current
		{
			get
			{
				bool[] array = new bool[_current.Length];
				Array.Copy(_current, array, array.Length);
				return array;
			}
		}
		
		private int _count;
		private bool[] _current;

		object IEnumerator.Current => Current;

		public BinaryCounter(int count)
		{
			_count = count;
			Size = 0;
			int range = 1;
			
			do
			{
				range *= 2;
				Size++;
			} while (range < _count);

			Reset();
		}

		public void Reset()
		{
			Index = -1;
			_current = new bool[Size];
			_current = _current.Select(e => true).ToArray();
		}

		public bool MoveNext()
		{
			Index++;

			for (int i = Size - 1; i > -1; i--)
			{
				_current[i] = !_current[i];
				if (_current[i]) break;
			}

			return Index < _count;
		}

		public void Dispose() { }
		
		public IEnumerator GetEnumerator() => this;

		IEnumerator<bool[]> IEnumerable<bool[]>.GetEnumerator() => this;
	}
}