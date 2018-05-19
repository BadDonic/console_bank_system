using System;
using console_bank_system.Decorator;

namespace console_bank_system.Menu.Command
{
	public class RegisterCommand : AbstractCommand
	{
		public RegisterCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine("\t >> Username: ");
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t >> Password: ");
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t >> Email: ");
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t >> Phone: ");
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t >> Money($): ");
			Console.WriteLine("-----------------------------------------------");
			Console.SetCursorPosition(23, 3);
			string username = Console.ReadLine();
			Console.SetCursorPosition(23, 5);
			string password = Console.ReadLine();
			Console.SetCursorPosition(20, 7);
			string email = Console.ReadLine();
			Console.SetCursorPosition(20, 9);
			string phone = Console.ReadLine();
			Console.SetCursorPosition(23, 11);
			string amount = Console.ReadLine();
			Console.Clear();
			bool result = true;
			Console.WriteLine("-----------------------------------------------");
			try
			{
				Bank.SignUp(new Account(username, password, email, phone, Double.Parse(amount))).Wait();
				Console.WriteLine("\t\tDONE!");
				result = false;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			GetConsoleKey();
			return result;
		}
	}
}