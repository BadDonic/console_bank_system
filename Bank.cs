using System.IO;
using System.Threading.Tasks;
using console_bank_system.Decorator;
using console_bank_system.Strategy;
using console_bank_system.Validation;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;


namespace console_bank_system
{
	public class Bank
	{
		private IMongoCollection<Account> Collection { get; set; }
		public bool IsLogin { get; private set; }
		public Account Account { get; set; }
		public Bank(string mongoDB_URI)
		{	
			MongoClient client = new MongoClient("");
			BsonClassMap.RegisterClassMap<CardMethod>();
			BsonClassMap.RegisterClassMap<CashMethod>();
			BsonClassMap.RegisterClassMap<BitCoinMethod>();
			var db = client.GetDatabase("bank_db");
			Collection = db.GetCollection<Account>("users");

		}

		public void Login(Account account)
		{
			AbstractValidation loginValidation = new UsernameValidation(new PasswordValidation(null));
			if (!loginValidation.Validate(account)) return;
			Account result = Collection.Find(user => user.Username == account.Username).FirstOrDefault();
			if (result == null)
				throw new InvalidDataException($"Does not Exist username: {account.Username}");
			if (result.Password != account.Password)
				throw new InvalidDataException($"Invalid password: {account.Password}");
			Account = result;
			IsLogin = true;
		}

		public async Task SignUp(Account account)
		{
			AbstractValidation signUpValidation = new UsernameValidation(new PasswordValidation(new EmailValidation(new PhoneValidation(null))));
			if (signUpValidation.Validate(account))
			{
				long result = Collection.Find(user => user.Username == account.Username).Count();
				if (result != 0)
					throw new InvalidDataException($"Username: {account.Username} is already EXIST!");
				Account = account;
				await Collection.InsertOneAsync(account);
				IsLogin = true;
			}
		}
		
		public void LogOut()
		{
			Collection.FindOneAndReplace(account => account.Username == Account.Username, Account);
			IsLogin = false;
		}
	}
}