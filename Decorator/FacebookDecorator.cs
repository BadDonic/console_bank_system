using System;

namespace console_bank_system.Decorator
{
	public class FacebookDecorator : BaseDecorator
	{
		public FacebookDecorator(Account account) : base(account)
		{
		}

		public new void SendNotification()
		{
			base.SendNotification();
			Console.WriteLine($"Send FACEBOOK notification on {Account.Username}");
		}
		
	}
}