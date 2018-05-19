using System;
using console_bank_system.Strategy;

namespace console_bank_system.Menu.Command
{
	public class TopUpCommand : AbstractCommand
	{
		public TopUpCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine($"\t >> Sum ({Bank.Account.State.Sign}): ");
			Console.SetCursorPosition(26, 3);
			Console.Clear();
			Console.WriteLine("-----------------------------------------------");
			string sum = Console.ReadLine();
			Bank.Account.TopUpThePhone(Double.Parse(sum));
			GetConsoleKey();
			return true;
		}
	}
	
	public class CashTopUpCommand : AbstractCommand
	{
		public CashTopUpCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine("\t\t DONE!!!");
			Bank.Account.Strategy = new CashMethod();
			GetConsoleKey();
			return true;
		}
	}
	
	public class CardTopUpCommand : AbstractCommand
	{
		public CardTopUpCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine("\t\t DONE!!!");
			Bank.Account.Strategy = new CardMethod();
			GetConsoleKey();
			return true;
		}
	}
	
	public class BitCoinTopUpCommand : AbstractCommand
	{
		public BitCoinTopUpCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Console.WriteLine("\t\t DONE!!!");
			Bank.Account.Strategy = new BitCoinMethod();
			GetConsoleKey();
			return true;
		}
	}
}