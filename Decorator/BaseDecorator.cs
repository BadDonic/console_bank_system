using console_bank_system.Decorator;
using console_bank_system.MoneyState;
using console_bank_system.Strategy;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system
{
	public class BaseDecorator : Account
	{
		[BsonIgnore]
		protected Account Account { get; set; }

		public BaseDecorator(Account account)
		{
			Account = account;
		}
		[BsonIgnore]
		public ObjectId Id { 
			get => Account.Id;
			set => Account.Id = value;
			
		}
		public new string Username
		{
			get => Account?.Username;
			set => Account.Username = value;
		}
		public new string Password
		{
			get => Account?.Password;
		}
		public new string Email
		{
			get => Account?.Email;
		}
		public new string Phone
		{
			get => Account?.Phone;
		}
		public new AbstractMoneyState State 
		{
			get => Account?.State;
		}
		public new IStrategy Strategy 
		{
			get => Account?.Strategy;
			set => Account.Strategy = value;
		}
		public new void ChangeState(AbstractMoneyState newState)
		{
			Account?.ChangeState(newState);
		}

		public new void ConvertToEUR()
		{
			Account?.ConvertToEUR();
		}

		public new void ConvertToUSD()
		{
			Account?.ConvertToUSD();
		}

		public new void ConvertToUAH()
		{
			Account?.ConvertToUAH();
		}

		public new void ConvertToRUB()
		{
			Account?.ConvertToRUB();
		}

		public new void WithDraw(double sum)
		{
			Account?.WithDraw(sum);
		}

		public new void TopUpThePhone(double sum)
		{
			Account?.TopUpThePhone(sum);
		}

		public new void SendNotification()
		{
			Account?.SendNotification();
		}
	}
}