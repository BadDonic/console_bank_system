using System;

namespace console_bank_system.Menu.Command
{
	public abstract class AbstractCommand
	{
		protected Bank Bank;

		public AbstractCommand(Bank bank)
		{
			Bank = bank;
		}
		public abstract bool Execute();

		protected void GetConsoleKey()
		{
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine("\t>> Enter some button to continue <<");
			Console.WriteLine("-----------------------------------------------");
			Console.ReadKey();
		}
	}
}