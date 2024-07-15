using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab7
{
	public partial class MainWindow : Window
	{
		private int Size
		{
			get => int.Parse(SizeInput.Text);
			set => SizeInput.Text = value.ToString();
		}

		private bool _oriented;
		private List<(int Y, int X)> _values;
		private DataTable _adjacency;

		public MainWindow()
		{
			InitializeComponent();
		}

		public DataTable CreateTable(int height, int width)
		{
			var table = new DataTable();

			for (int x = 0; x < width; x++) table.Columns.Add(new DataColumn(x.ToString()));

			for (int y = 0; y < height; y++)
			{
				var row = table.NewRow();
				for (int x = 0; x < width; x++) row[x] = "0";
				table.Rows.Add(row);
			}

			return table;
		}

		public void Read()
		{
			_values = [];
			_oriented = true;

			for (int y = 0; y < Adjacency.Columns.Count; y++)
			{
				for (int x = 0; x < Adjacency.Columns.Count; x++)
				{
					if (Read(y, x)) _values.Add((y, x));
					if (Read(y, x) != Read(x, y)) _oriented = false;
				}
			}

			if (_oriented)
			{
				for (int y = 0; y < Adjacency.Columns.Count; y++)
				{
					for (int x = 0; x < Adjacency.Columns.Count; x++)
					{
						if (_values.Any(e => x != y && e.Y == y && e.X == x))
							_values.Remove(_values.First(e => e.Y == x && e.X == y));
					}
				}
			}
		}

		private bool Read(int y, int x)
		{
			var row = Adjacency.Items[y];
			var column = Adjacency.Columns[x];

			var content = column.GetCellContent(row);
			if (content is TextBlock textBlock)
				return textBlock.Text == "1";
			else if (content is ContentPresenter presenter && presenter.Content is TextBlock textBlockFromPresenter)
				return textBlockFromPresenter.Text == "1";

			return false;
		}

		private void ShowIncidence()
		{
			var incidence = CreateTable(_adjacency.Columns.Count, _values.Count);
			
			for (int i = 0; i < _values.Count; i++)
			{
				if (_values[i].Y == _values[i].X) incidence.Rows[_values[i].Y][i] = 2;
				else
				{
					incidence.Rows[_values[i].Y][i] = 1;
					incidence.Rows[_values[i].X][i] = _oriented ? 1 : -1;
				}
			}

			Incidence.ItemsSource = incidence.DefaultView;
		}

		private void ShowList()
		{
			List.Items.Clear();
			foreach (var (Y, X) in _values) List.Items.Add($"[{Y}, {X}]");
		}

		private void CreateAdjacency(int size, bool oriented, params (int Y, int X)[] vertices)
		{
			Size = size;
			_adjacency = CreateTable(Size, Size);
			foreach (var (Y, X) in vertices)
			{
				_adjacency.Rows[Y - 1][X - 1] = 1;
				if (!oriented) _adjacency.Rows[X - 1][Y - 1] = 1;
			}

			Adjacency.ItemsSource = _adjacency.DefaultView;
		}

		private void Adjacency_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var dep = (DependencyObject)e.OriginalSource;

			while ((dep != null) && dep is not DataGridCell) dep = VisualTreeHelper.GetParent(dep);

			if (dep is DataGridCell cell)
			{
				string cellValue = (cell.Content as TextBlock)?.Text;

				if (cellValue != null)
				{
					int currentValue;
					if (int.TryParse(cellValue, out currentValue))
					{
						int newValue = (currentValue == 1) ? 0 : 1;
						cell.Content = new TextBlock { Text = newValue.ToString() };
					}
				}
			}
		}

		private void Transform_Click(object sender, RoutedEventArgs e)
		{
			Read();
			ShowIncidence();
			ShowList();
		}

		private void Create_Click(object sender, RoutedEventArgs e)
		{
			Adjacency.ItemsSource = (_adjacency = CreateTable(Size, Size)).DefaultView;
		}


		private void Unoriented_Click(object sender, RoutedEventArgs e)
		{
			CreateAdjacency(3, false, (1, 2), (1, 3), (2, 3), (3, 3));
		}

		private void Oriented_Click(object sender, RoutedEventArgs e)
		{
			CreateAdjacency(4, true, (1, 2), (2, 3), (2, 4), (3, 1), (4, 3));
		}
	}
}