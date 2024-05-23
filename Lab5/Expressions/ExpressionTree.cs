using System.Collections;

namespace Lab5.Expressions.Types
{
	internal class ExpressionTree(Expression root)
    {
        private Expression _root = root;
        private List<Expression> _list = [];

        private void AddSubTree(Expression root)
        {
            if (root != null)
            {
				_list.Add(root);
                AddSubTree(root.Left);
                AddSubTree(root.Right);
            }
        }

        private void CreateList()
        {
            AddSubTree(_root);
			_list.Sort((x, y) => y.GetLayer() - x.GetLayer());
        }

        public List<string[]> ToTable()
        {
            CreateList();

			var counter = new BinaryCounter(4);
            var results = new List<bool[]>();

			foreach (BitArray values in counter)
            {
                results.Add(new bool[_list.Count]);
				for (int x = 0; x < _list.Count; x++)
                {
                    _list[x].Calculate(values);
                    results[^1][x] = _list[x].Value;
				}
			}

			var columns = new List<string[]>();

			for (int x = 0, y = 1; x < _list.Count; x++, y = 1)
            {
                columns.Add(new string[5]);
                columns[^1][0] = _list[x].ToString();

                counter.Reset();
				foreach (BitArray values in counter)
                {
                    columns[^1][y] = (results[y - 1][x] ? "1" : "0").PadLeft(columns[^1][0].Length / 2 + 1).PadRight(columns[^1][0].Length);
                    y++;
				}
			}

            return columns;
        }
    }
}