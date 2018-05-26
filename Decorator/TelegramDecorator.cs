using System;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Decorator
{
	[BsonDiscriminator("TelegramDecorator")]
	public class TelegramDecorator : BaseDecorator
	{
		public TelegramDecorator(Account account) : base(account)
		{
		}

		public override void SendNotification()
		{
			base.SendNotification();
			Console.WriteLine($"Send TELEGRAM notification on {Account.Phone}");
		}
	} 
}