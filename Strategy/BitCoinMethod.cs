using System;
using console_bank_system.Decorator;

namespace console_bank_system.Strategy
{
	public class BitCoinMethod : IStrategy
	{
		public void TopUpThePhone(double sum, Account account)
		{
			Console.WriteLine($"\t\tBITCOIN METHOD");
			Console.WriteLine($"My phone : {account.Phone} was toped up on {sum + account.State.Sign}");
		}
	}
}