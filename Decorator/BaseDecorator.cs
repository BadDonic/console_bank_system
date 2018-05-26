using console_bank_system.Decorator;
using console_bank_system.MoneyState;
using console_bank_system.Strategy;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system
{
	public class BaseDecorator : Account
	{
		protected Account Account { get; set; }

		protected BaseDecorator(Account account)
		{
			Account = account;
		}
		[BsonIgnore]
		public override ObjectId Id { 
			get => Account.Id;
			set => Account.Id = value;
		}
		public override string Username
		{
			get => Account.Username;
			set => Account.Username = value;
		}
		public override string Password
		{
			get => Account.Password;
		}
		public override string Email
		{
			get => Account.Email;
		}
		public override string Phone
		{
			get => Account.Phone;
		}
		public override AbstractMoneyState State 
		{
			get => Account.State;
		}
		public override IStrategy Strategy 
		{
			get => Account.Strategy;
			set => Account.Strategy = value;
		}

		public override void ConvertToEUR()
		{
			Account?.ConvertToEUR();
		}

		public override void ConvertToUSD()
		{
			Account?.ConvertToUSD();
		}

		public override void ConvertToUAH()
		{
			Account?.ConvertToUAH();
		}

		public override void ConvertToRUB()
		{
			Account?.ConvertToRUB();
		}

		public override void WithDraw(double sum)
		{
			Account?.WithDraw(sum);
		}

		public override void TopUpThePhone(double sum)
		{
			Account?.TopUpThePhone(sum);
		}

		public override void SendNotification()
		{
			Account?.SendNotification();
		}
	}
}