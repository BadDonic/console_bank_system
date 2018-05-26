using System;
using console_bank_system.Decorator;

namespace console_bank_system.Menu.Command
{
	public class LoginCommand : AbstractCommand
	{
		public LoginCommand(Bank bank) : base(bank)
		{
		}
		public override bool Execute()
		{
			Console.WriteLine("\t >> Username: ");
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t >> Password: ");
			Console.WriteLine("-----------------------------------------------");
			Console.SetCursorPosition(23, 3);
			string username = Console.ReadLine();
			Console.SetCursorPosition(23, 5);
			string password = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("-----------------------------------------------");
			try
			{
//				Bank.Login(new Account("Daniel", "qb9jzlqb"));
				Bank.Login(new Account(username, password));
				Console.WriteLine("\t\tDONE!");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			GetConsoleKey();
			return true;
		}
	}
}