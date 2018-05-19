using System;
using console_bank_system.Decorator;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Strategy
{
	[BsonDiscriminator("CardMethod")]
	public class CardMethod : IStrategy
	{
		public void TopUpThePhone(double sum, Account account)
		{
			Console.WriteLine($"CARD METHOD");
			try
			{
				account.WithDraw(sum);
				Console.WriteLine($"My phone : {account.Phone} was toped up on {sum + account.State.Sign}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
