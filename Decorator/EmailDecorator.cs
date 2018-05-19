using System;

namespace console_bank_system.Decorator
{
	public class EmailDecorator : BaseDecorator
	{
		public EmailDecorator(Account account) : base(account)
		{
		}

		public void SendNotification()
		{
			base.SendNotification();
			Console.WriteLine($"Send EMAIL notification on {Account.Email}");
		}
	}
}