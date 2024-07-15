using Lab6;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

while (true)
{
	try
	{
		var menu = new Menu();
		var function = menu.InputFunction();
		var analyzes = Analyzer.Analyze(function, out bool[] linear);
		menu.Output(analyzes, ["Функція зберігає константу 0", "Функція зберігає константу 1", "Функція самодвоїста", "Функція лінійна"]);
		if (analyzes[3]) menu.Output(linear);
		var formatter = new Formatter(function);
		menu.Output(formatter.CreateDisjunctiveForm(), ['∨', '∧'], "ДДНФ");
		menu.Output(formatter.CreateConjunctiveForm(), ['∧', '∨'], "ДКНФ");
	}
	catch (Exception exception) { Console.WriteLine($"Помилка: {exception.Message}"); }
}