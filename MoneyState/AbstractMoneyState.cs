using console_bank_system.Decorator;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.MoneyState
{
	[BsonKnownTypes(typeof(RUBState), typeof(UAHState), typeof(USDState), typeof(EURState))]
	public abstract class AbstractMoneyState
	{
		public double Amount { get; set; }
		public string Sign { get; protected set; }

		protected AbstractMoneyState(double amount)
		{
			Amount = amount;
		}

		public abstract AbstractMoneyState ConvertToEUR();
		public abstract AbstractMoneyState ConvertToUSD();
		public abstract AbstractMoneyState ConvertToUAH();
		public abstract AbstractMoneyState ConvertToRUB();
	}
}