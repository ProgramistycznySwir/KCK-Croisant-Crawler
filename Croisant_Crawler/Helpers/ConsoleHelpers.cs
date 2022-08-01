namespace Croisant_Crawler.Helpers;

internal static class ConsoleHelper
{
	public static void Wait()
	{
		while(Console.ReadKey(true).Key is not ConsoleKey.Enter);
	}
	public static ConsoleKey TakeInput()
	{
		ConsoleKey key = Console.ReadKey(true).Key;
		if(key is ConsoleKey.Escape)
			System.Environment.Exit(0);
		return key;
	}
}