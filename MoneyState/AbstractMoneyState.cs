using console_bank_system.Decorator;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.MoneyState
{
	[BsonKnownTypes(typeof(RUBState), typeof(UAHState), typeof(USDState), typeof(EURState))]
	public abstract class AbstractMoneyState
	{
		public double Amount { get; set; }
		protected Account Account { get; set; }
		public string Sign { get; protected set; }

		protected AbstractMoneyState(double amount, Account account)
		{
			Amount = amount;
			Account = account;
		}

		public abstract void ConvertToEUR();
		public abstract void ConvertToUSD();
		public abstract void ConvertToUAH();
		public abstract void ConvertToRUB();
	}
}