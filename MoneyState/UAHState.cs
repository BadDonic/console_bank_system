using console_bank_system.Decorator;

namespace console_bank_system.MoneyState
{
	public class UAHState : AbstractMoneyState
	{
		public UAHState(double amount) : base(amount)
		{
			Sign = "UAH";
		}

		public override AbstractMoneyState ConvertToEUR()
		{
			return new EURState(Amount * 0.032);
		}

		public override AbstractMoneyState ConvertToUSD()
		{
			return new USDState(Amount * 0.0383);
		}

		public override AbstractMoneyState ConvertToUAH()
		{
			return this;
		}

		public override AbstractMoneyState ConvertToRUB()
		{
			return new RUBState(Amount * 2.38);
		}
	}
}