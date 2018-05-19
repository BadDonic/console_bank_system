using System;
using console_bank_system.Decorator;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Strategy
{
	[BsonDiscriminator("BitCoinMethod")]
	public class BitCoinMethod : IStrategy
	{
		public void TopUpThePhone(double sum, Account account)
		{
			Console.WriteLine($"\t\tBITCOIN METHOD");
			Console.WriteLine($"My phone : {account.Phone} was toped up on {sum + account.State.Sign}");
		}
	}
}