using System;

namespace console_bank_system.Menu.Command
{
	public class ContactBankCommand : AbstractCommand
	{
		public ContactBankCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine("   Email: " + Bank.Email);
			Console.WriteLine("   Phone: " + Bank.Phone);
			GetConsoleKey();
			return true;
		}
	}
}