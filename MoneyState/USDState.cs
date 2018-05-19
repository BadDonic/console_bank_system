using console_bank_system.Decorator;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.MoneyState
{
	public class USDState : AbstractMoneyState
	{
		public USDState(double amount, Account account) : base(amount, account)
		{
			Sign = "$";
		}

		public override void ConvertToEUR()
		{
			Account.ChangeState(new EURState(Amount * 0.85, Account));
		}

		public override void ConvertToUSD()
		{
		}

		public override void ConvertToUAH()
		{
			Account.ChangeState(new UAHState(Amount * 26.11, Account));
		}

		public override void ConvertToRUB()
		{
			Account.ChangeState(new RUBState(Amount * 62.32, Account));
		}
	}
}