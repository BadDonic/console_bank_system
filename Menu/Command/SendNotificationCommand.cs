using System;
using console_bank_system.Decorator;

namespace console_bank_system.Menu.Command
{
	public class SendNotificationCommand : AbstractCommand
	{
		public SendNotificationCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account.SendNotification();
			GetConsoleKey();
			return true;
		}
	}
	
	public class EmailNotificationCommand : AbstractCommand
	{
		public EmailNotificationCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account = new EmailDecorator(Bank.Account);
			Console.WriteLine(Bank.Account);
			Console.WriteLine(Bank.Account.Username);
			Console.WriteLine(Bank.Account.State.Amount);
			Console.WriteLine(Bank.Account.State.Sign);

			Console.WriteLine("\t\tDONE!");
			GetConsoleKey();
			return true;
		}
	}
	
	public class FacebookNotificationCommand : AbstractCommand
	{
		public FacebookNotificationCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account = new FacebookDecorator(Bank.Account);
			Console.WriteLine("\t\tDONE!");
			GetConsoleKey();
			return true;
		}
	}
	
	public class TelegramNotificationCommand : AbstractCommand
	{
		public TelegramNotificationCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account = new TelegramDecorator(Bank.Account);
			Console.WriteLine("\t\tDONE!");
			GetConsoleKey();
			return true;
		}
	}
}