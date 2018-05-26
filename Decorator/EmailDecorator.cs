using System;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Decorator
{
	[BsonDiscriminator("EmailDecorator")]
	public class EmailDecorator : BaseDecorator
	{
		public EmailDecorator(Account account) : base(account)
		{
		}

		public override void SendNotification()
		{
			base.SendNotification();
			Console.WriteLine($"Send EMAIL notification on {Account.Email}");
		}
	}
}