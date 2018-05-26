using System;
using System.IO;
using console_bank_system.MoneyState;
using console_bank_system.Strategy;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Decorator
{
	[BsonKnownTypes(typeof(EmailDecorator), typeof(FacebookDecorator), typeof(TelegramDecorator), typeof(Account))]
	[BsonDiscriminator("Account")]
	public class Account
	{
		public virtual ObjectId Id { get; set; }
		public virtual string Username { get; set; }
		public virtual string Password { get; private set; }
		public virtual string Email { get; private set; }
		public virtual string Phone { get; private set; }
		public virtual AbstractMoneyState State { get; private set; }
		public virtual IStrategy Strategy { get; set; }
		
		public Account(string username, string password)
		{
			Username = username;
			Password = password;
			Strategy = new CardMethod();
			State = new USDState(0);
		}

		public Account(string username, string password, string email, string phone, double amount)
		{
			State = new USDState(amount);
			Username = username;
			Password = password;
			Email = email;
			Phone = phone;
			Strategy = new CardMethod();
		}

		protected Account()
		{
		}

		public virtual void ConvertToEUR()
		{
			State = State?.ConvertToEUR();
		}

		public virtual void ConvertToUSD()
		{
			State = State?.ConvertToUSD();
		}

		public virtual void ConvertToUAH()
		{
			State = State?.ConvertToUAH();
		}

		public virtual void ConvertToRUB()
		{
			State = State?.ConvertToRUB();
		}

		public virtual void WithDraw(double sum)
		{
			if (State.Amount < sum)
				throw new InvalidDataException("Insufficient funds!!!");
			State.Amount = State.Amount - sum;
		}

		public virtual void TopUpThePhone(double sum)
		{
			Strategy?.TopUpThePhone(sum, this);
		}

		public virtual void SendNotification()
		{
			Console.WriteLine(typeof(Account));
			Console.WriteLine("After each operation:");
			Console.WriteLine($"Send SMS - notification on phone: {Phone}");
		}
	}
}