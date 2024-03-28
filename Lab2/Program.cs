using Lab2;
using System.Text;

while (true)
{
	Console.OutputEncoding = Encoding.UTF8;

	Console.WriteLine("\nВведіть множини:");
	Calculator calc = new(Menu.Input("U"), Menu.Input("A"), Menu.Input("b"));

	Menu.Output("A ⋃ B", calc.ToSet(calc.Unite()));
	Menu.Output("A ⋂ B", calc.ToSet(calc.Cross()));
	Menu.Output("A \\ B", calc.ToSet(calc.Subtract(calc.A, calc.B)));
	Menu.Output("B \\ A", calc.ToSet(calc.Subtract(calc.B, calc.A)));
	Menu.Output("A Δ B", calc.ToSet(calc.SymmSubtract()));
	Menu.Output("A × B", calc.CartesianProduct(calc.A, calc.B));
	Menu.Output("B × A", calc.CartesianProduct(calc.B, calc.A));
}