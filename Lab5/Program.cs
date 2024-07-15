using Lab5;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

while (true)
{
	try { Menu.Playback(); }
	catch (Exception exception) { Console.WriteLine($"Помилка: {exception.Message}"); }
}