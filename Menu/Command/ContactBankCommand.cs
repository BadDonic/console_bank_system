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
			Console.WriteLine("   Email: dzenik1999gmail.com");
			Console.WriteLine("   Phone: (063) - 602 - 44 - 56");
			GetConsoleKey();
			return true;
		}
	}
}