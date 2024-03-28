using Lab3;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

while (true)
{
	var matrix = Menu.Input("Введіть матрицю"); 
	Menu.Output(Solution.CheckReflexivity(matrix), "ні рефлексивне ні антирефлексивне", "рефлексивне", "антирефлексивне");
	Menu.Output(Solution.CheckSymmetry(matrix), "ні симетричне ні антисиметричне", "симетричне", "антисиметричне");
	Menu.Output(Solution.CheckTransitivity(matrix), "нетранзитивне", "транзитивне");
	Console.WriteLine("\n");
}