using Lab1;
using System.Text;

while (true)
{
	Console.OutputEncoding = Encoding.UTF8;

	Console.WriteLine("\nВведіть множини:");
	List<string> a = Menu.Input("A"), b = Menu.Input("B");
	Menu.Output("A ⋃ B", Caclulator.Unite(a, b));
	Menu.Output("A ⋂ B", Caclulator.Cross(a, b));
	Menu.Output("A \\ B", Caclulator.Subtract(a, b));
	Menu.Output("B \\ A", Caclulator.Subtract(b, a));
	Menu.Output("A Δ B", Caclulator.SymmSubtract(a, b));
	Console.WriteLine((Caclulator.CheckIfSub(a, b) ? $"A ∈ B" : $"A ∉ B") + " й " + (Caclulator.CheckIfSub(b, a) ? $"B ∈ A" : $"B ∉ A") +  " => " + (Caclulator.CheckIfEqual(b, a) ? $"A = B" : $"A ≠ B"));
}