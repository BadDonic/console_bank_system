using System;

namespace console_bank_system.Decorator
{
	public class TelegramDecorator : BaseDecorator
	{
		public TelegramDecorator(Account account) : base(account)
		{
		}

		public new void SendNotification()
		{
			base.SendNotification();
			Console.WriteLine($"Send TELEGRAM notification on {Account.Phone}");
		}
	} 
}