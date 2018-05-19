using console_bank_system.Decorator;

namespace console_bank_system.MoneyState
{
	public class RUBState : AbstractMoneyState
	{
		public RUBState(double amount, Account account) : base(amount, account)
		{
			Sign = "RUB";
		}

		public override void ConvertToEUR()
		{
			Account.ChangeState(new EURState(Amount * 0.014, Account));
		}

		public override void ConvertToUSD()
		{
			Account.ChangeState(new USDState(Amount * 0.016, Account));
		}

		public override void ConvertToUAH()
		{
			Account.ChangeState(new UAHState(Amount * 0.42, Account));
		}

		public override void ConvertToRUB()
		{
		}
	}
}