using System;

namespace console_bank_system.Menu.Command
{
	public class AccountInfoCommand : AbstractCommand
	{
		public AccountInfoCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine($"Money: {Bank.Account.State.Amount + Bank.Account.State.Sign}");
			Console.WriteLine($"Username: {Bank.Account.Username}");
			Console.WriteLine($"Password: {Bank.Account.Password}");
			Console.WriteLine($"Email: {Bank.Account.Email}");
			Console.WriteLine($"Phone: {Bank.Account.Phone}");
			GetConsoleKey();
			return true;
		}
	}
}