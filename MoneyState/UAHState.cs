using console_bank_system.Decorator;

namespace console_bank_system.MoneyState
{
	public class UAHState : AbstractMoneyState
	{
		public UAHState(double amount, Account account) : base(amount, account)
		{
			Sign = "UAH";
		}

		public override void ConvertToEUR()
		{
			Account.ChangeState(new EURState(Amount * 0.032, Account));
		}

		public override void ConvertToUSD()
		{
			Account.ChangeState(new USDState(Amount * 0.0383, Account));
		}

		public override void ConvertToUAH()
		{
		}

		public override void ConvertToRUB()
		{
			Account.ChangeState(new RUBState(Amount * 2.38, Account));
		}
	}
}