using System;

namespace console_bank_system.Menu.Command
{
	public class RegisterCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t >> REGISTRATION << \t");
			Console.WriteLine("-----------------------------------------------");
			Console.ReadKey();
		}
	}
}