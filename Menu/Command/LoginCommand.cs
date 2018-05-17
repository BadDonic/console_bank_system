using System;

namespace console_bank_system.Menu.Command
{
	public class LoginCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t >> LOGIN << \t");
			Console.WriteLine("-----------------------------------------------");
			Console.ReadKey();
		}
	}
}