using System;
using System.IO;
using console_bank_system.MoneyState;
using console_bank_system.Strategy;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace console_bank_system.Decorator
{
//	[BsonKnownTypes(typeof(BaseDecorator), typeof(EmailDecorator), typeof(FacebookDecorator), typeof(TelegramDecorator))]
	public class Account
	{		
		public ObjectId Id { get; set; }
		public string Username { get; set; }
		public string Password { get; private set; }
		public string Email { get; private set; }
		public string Phone { get; private set; }
		public AbstractMoneyState State { get; private set; }
		public IStrategy Strategy { get; set; }
		
		protected Account()
		{
			Strategy = new CardMethod();
			State = new USDState(0, this);
		}

		public Account(string username, string password) : this()
		{
			Username = username;
			Password = password;
		}
		
		public Account(string username, string password, string email, string phone, double amount) : this()
		{
			State = new USDState(amount, this);
			Username = username;
			Password = password;
			Email = email;
			Phone = phone;
		}

		public void ChangeState(AbstractMoneyState newState)
		{
			State = newState;
		}

		public void ConvertToEUR()
		{
			State?.ConvertToEUR();
		}

		public void ConvertToUSD()
		{
			State?.ConvertToUSD();
		}

		public void ConvertToUAH()
		{
			State?.ConvertToUAH();
		}

		public void ConvertToRUB()
		{
			State?.ConvertToRUB();
		}

		public void WithDraw(double sum)
		{
			if (State.Amount < sum)
				throw new InvalidDataException("Insufficient funds!!!");
			State.Amount = State.Amount - sum;
		}

		public void TopUpThePhone(double sum)
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