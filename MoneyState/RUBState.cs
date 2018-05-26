using console_bank_system.Decorator;

namespace console_bank_system.MoneyState
{
	public class RUBState : AbstractMoneyState
	{
		public RUBState(double amount) : base(amount)
		{
			Sign = "RUB";
		}

		public override AbstractMoneyState ConvertToEUR()
		{
			return new EURState(Amount * 0.014);
		}

		public override AbstractMoneyState ConvertToUSD()
		{
			return new USDState(Amount * 0.016);
		}

		public override AbstractMoneyState ConvertToUAH()
		{
			return new UAHState(Amount * 0.42);
		}

		public override AbstractMoneyState ConvertToRUB()
		{
			return this;
		}
	}
}