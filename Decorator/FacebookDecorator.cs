using System;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Decorator
{
	[BsonDiscriminator("FacebookDecorator")]
	public class FacebookDecorator : BaseDecorator
	{
		public FacebookDecorator(Account account) : base(account)
		{
		}

		public override void SendNotification()
		{
			base.SendNotification();
			Console.WriteLine($"Send FACEBOOK notification on {Account.Username}");
		}
		
	}
}