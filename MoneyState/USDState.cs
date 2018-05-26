using console_bank_system.Decorator;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.MoneyState
{
	public class USDState : AbstractMoneyState
	{
		public USDState(double amount) : base(amount)
		{
			Sign = "$";
		}

		public override AbstractMoneyState ConvertToEUR()
		{
			return new EURState(Amount * 0.85);
		}

		public override AbstractMoneyState ConvertToUSD()
		{
			return this;
		}

		public override AbstractMoneyState ConvertToUAH()
		{
			return new UAHState(Amount * 26.11);
		}

		public override AbstractMoneyState ConvertToRUB()
		{
			return new RUBState(Amount * 62.32);
		}
	}
}