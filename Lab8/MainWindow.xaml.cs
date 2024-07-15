using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab8
{
	public partial class MainWindow : Window
	{
		private double[] _a, _b;

		public MainWindow()
		{
			InitializeComponent();

			_a = new double[20];
			_b = new double[20];
			
			_a[7] = _a[8] = _a[9] = _a[10] = _a[11] = 1;
			_a[6] = _a[12] = 0.8;
			_a[5] = _a[13] = 0.61;
			_a[4] = _a[14] = 0.41;
			_a[3] = _a[15] = 0.23;
			_a[2] = _a[16] = 0.1;

			_b[0] = _b[1] = _b[2] = _b[16] = _b[17] = _b[18] = _b[19] = 1;
			_b[3] = _b[15] = 0.9;
			_b[4] = _b[14] = 0.7;
			_b[5] = _b[13] = 0.4;
		}

		private void Draw(Canvas canvas, Color color, int thickness, double[] set, double height = 0)
		{
			for (int i = 0; i < set.Length - 1; i++)
			{
				if (set[i] < height || set[i + 1] < height) continue;

				var first = GetPoint(canvas, i, set[i], set.Length - 1);
				var last = GetPoint(canvas, i + 1, set[i + 1], set.Length - 1);

				var line = new Line
				{
					Stroke = new SolidColorBrush(color),
					StrokeThickness = thickness,
					X1 = first.X,
					Y1 = first.Y,
					X2 = last.X,
					Y2 = last.Y
				};

				canvas.Children.Add(line);
			}
		}

		private void DrawA(int thickness, double height = 0)
		{
			Draw(TopCanvas, Color.FromRgb(0, 48, 73), thickness, _a, height);
		}

		private void DrawB(int thickness, double height = 0)
		{
			Draw(TopCanvas, Color.FromRgb(193, 18, 31), thickness, _b, height);
		}

		private void A_Click(object sender, RoutedEventArgs e)
		{
			TopCanvas.Children.Clear();
			DrawA(3);
		}

		private void DrawATwice(double height)
		{
			TopCanvas.Children.Clear();
			DrawA(1);
			DrawA(3, height);
		}

		private void A1_Click(object sender, RoutedEventArgs e)
		{
			DrawATwice(1d / double.MaxValue);
		}

		private void A2_Click(object sender, RoutedEventArgs e)
		{
			DrawATwice(1);
		}

		private void A3_Click(object sender, RoutedEventArgs e)
		{
			DrawATwice(0.8);
		}

		private void A4_Click(object sender, RoutedEventArgs e)
		{
			DrawATwice(0.6);
		}

		private void A5_Click(object sender, RoutedEventArgs e)
		{
			DrawATwice(0.4);
		}

		private void A6_Click(object sender, RoutedEventArgs e)
		{
			DrawATwice(0.1);
		}

		private void B_Click(object sender, RoutedEventArgs e)
		{
			TopCanvas.Children.Clear();
			DrawB(3);
		}

		private void DrawC(Func<double, double, double> dependency)
		{
			TopCanvas.Children.Clear();
			Draw(TopCanvas, Color.FromRgb(123, 44, 91), 3, Enumerable.Range(0, _a.Length).Select(i => dependency(_a[i], _b[i])).ToArray(), 0);
		}

		private void C1_Click(object sender, RoutedEventArgs e)
		{
			DrawC(Math.Max);
		}

		private void C2_Click(object sender, RoutedEventArgs e)
		{
			DrawC(Math.Min);
		}

		private double GetTemperature(int value)
		{
			int[] t = [10, 20, 25, 30];
			double result = 1;
			if (value >= t[1] && value <= t[2]) result = 1;
			else if (value < t[1]) result = (double)(t[0] - value) / (t[0] - t[1]);
			else result = (double)(t[3] - value) / (t[3] - t[2]);
			result = Math.Pow(result, 3);
			return result < 0 ? 0 : result > 1 ? 1 : result;
		}

		private void C3_Click(object sender, RoutedEventArgs e)
		{
			int[] range = [0, 40];
			Draw(BottomCanvas, Color.FromRgb(123, 44, 91), 3, Enumerable.Range(range[0], range[1]).Select(GetTemperature).ToArray());
			MinT.Content = range[0].ToString();
			MaxT.Content = range[1].ToString();
		}

		private Point GetPoint(Canvas canvas, int x, double y, int width) => new (canvas.Width * x / width, canvas.Height * (1 - y));
	}
}