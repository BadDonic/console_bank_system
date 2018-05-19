using console_bank_system.Decorator;

namespace console_bank_system.MoneyState
{
	public class EURState : AbstractMoneyState
	{
		public EURState(double amount, Account account) : base(amount, account)
		{
			Sign = "€";
		}

		public override void ConvertToEUR()
		{
		}

		public override void ConvertToUSD()
		{
			Account.ChangeState(new USDState(Amount * 1.18, Account));
		}

		public override void ConvertToUAH()
		{
			Account.ChangeState(new UAHState(Amount * 30.88, Account));
		}

		public override void ConvertToRUB()
		{
			Account.ChangeState(new RUBState(Amount * 74.48, Account));
		}
	}
}