using System;

namespace console_bank_system.Menu.Command
{
	public class AboutBankCommand : AbstractCommand
	{
		public AboutBankCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine("   " + Bank.Info);
			GetConsoleKey();
			return true;
		}
	}
}