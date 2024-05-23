using System.Collections;

namespace Lab5
{
	internal class BinaryCounter : IEnumerable<BitArray>, IEnumerator<BitArray>
	{
		public BitArray Current { get; private set; }
		
		private int _size;
		private int _count;
		private int _counter;

		object IEnumerator.Current => Current;

		public BinaryCounter(int count)
		{
			_count = count;
			_size = 0;
			int range = 1;
			
			do
			{
				range *= 2;
				_size++;
			} while (range < _count);

			Reset();
		}

		public void Reset()
		{
			_counter = -1;
			Current = new BitArray(_size, true);
		}

		public bool MoveNext()
		{
			_counter++;

			for (int i = _size - 1; i > -1; i--)
			{
				Current[i] = !Current[i];
				if (Current[i]) break;
			}

			return _counter < _count;
		}

		public void Dispose() { }
		
		public IEnumerator GetEnumerator() => this;

		IEnumerator<BitArray> IEnumerable<BitArray>.GetEnumerator() => this;
	}
}