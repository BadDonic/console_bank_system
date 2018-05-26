using console_bank_system.Decorator;

namespace console_bank_system.MoneyState
{
	public class EURState : AbstractMoneyState
	{
		public EURState(double amount) : base(amount)
		{
			Sign = "€";
		}

		public override AbstractMoneyState ConvertToEUR()
		{
			return this;
		}

		public override AbstractMoneyState ConvertToUSD()
		{
			return new USDState(Amount * 1.18);
		}

		public override AbstractMoneyState ConvertToUAH()
		{
			return new UAHState(Amount * 30.88);
		}

		public override AbstractMoneyState ConvertToRUB()
		{
			return new RUBState(Amount * 74.48);
		}
	}
}