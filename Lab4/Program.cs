using Lab4;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

while (true)
{
	try
	{
		int a = Menu.Input("перше число"), b = Menu.Input("друге число");
		Menu.Output("НСД", Soluction.GreatestCommonDiviser(a, b));
		Menu.Output("НСЛ", Soluction.LeastCommonMultiple(a, b));
		Menu.Output($"Роклад на прості множники числа 1", Soluction.GetPrimeFactors(a));
		Menu.Output($"Роклад на прості множники числа 2", Soluction.GetPrimeFactors(b));
		Menu.Output($"Числа для яких справджується конгруентність", Soluction.FindCongruentNumbers(a, b));
		Menu.Output($"Прості числа до найбільшого з введених", Soluction.GetPrimeNumbers(a, b));
		Console.WriteLine('\n');
	}
	catch { Console.Clear(); }
}