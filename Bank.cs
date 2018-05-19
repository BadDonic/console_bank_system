using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using console_bank_system.Decorator;
using console_bank_system.Menu;
using console_bank_system.Menu.Command;
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

		private Composite _mainMenu;
		private Composite _accountMenu;

		private AbstractValidation _loginValidation;
		private AbstractValidation _signUpValidation;
		
		public string Description { get; set; }

		public Bank()
		{
			_mainMenu = CreateMainMenu();
			
			_loginValidation = new UsernameValidation(new PasswordValidation(null));
			_signUpValidation = new UsernameValidation(new PasswordValidation(new EmailValidation(new PhoneValidation(null))));

			MongoClient client = new MongoClient("mongodb://BadDonic:qb9jzlqb@ds227740.mlab.com:27740/bank_db");
			BsonClassMap.RegisterClassMap<CardMethod>();
			var db = client.GetDatabase("bank_db");
			Collection = db.GetCollection<Account>("users");

			Description = "My Bank - is the largest commercial bank in Ukraine,[4] in terms of the number of clients, assets value, loan portfolio and taxes paid to the national budget. PrivatBank has its headquarters in Dnipro, in central Ukraine.";
		}

		public void Login(Account account)
		{
			if (_loginValidation.Validate(account))
			{
				Account result = Collection.Find(user => user.Username == account.Username).FirstOrDefault();
				if (result == null)
					throw new InvalidDataException($"Does not Exist username: {account.Username}");
				if (result.Password != account.Password)
					throw new InvalidDataException($"Invalid password: {account.Password}");
				Account = result;
				IsLogin = true;
			}
		}

		public async Task SignUp(Account account)
		{
			if (_signUpValidation.Validate(account))
			{
				long result = Collection.Find(user => user.Username == account.Username).Count();
				if (result != 0)
					throw new InvalidDataException($"Username: {account.Username} is already EXIST!");
				Account = account;
				await Collection.InsertOneAsync(account);
				IsLogin = true;
			}
		}

		public void Start()
		{
			_mainMenu.Execute();
			if (IsLogin)
			{
				_accountMenu = CreateAccountMenu();
				_accountMenu.Execute();
			}
		}

		public void LogOut()
		{
			Collection.FindOneAndReplace(account => account.Username == Account.Username, Account);
			IsLogin = false;
			Start();
		}

		private Composite CreateAccountMenu()
		{
			Composite menu =  new Composite(Account.Username, this, false);
			
			Invoker info = new Invoker("Info", new AccountInfoCommand(this));
			menu.AddChild(info);
			
			Invoker topUpThePhone = new Invoker("Top Up The Phone", new TopUpCommand(this));
			menu.AddChild(topUpThePhone);
			
			Invoker sendNotification = new Invoker("Send Notification", new SendNotificationCommand(this));
			menu.AddChild(sendNotification);
			
			Composite converts =  new Composite("Convert", this);
			Invoker USD = new Invoker("TO_USD", new ConvertToUSDCommand(this));
			Invoker EUR = new Invoker("TO_EUR", new ConvertToEURCommand(this));
			Invoker UAH = new Invoker("TO_UAH", new ConvertToUAHCommand(this));
			Invoker RUB = new Invoker("TO_RUB", new ConvertToRUBCommand(this));
			converts.AddChild(USD);
			converts.AddChild(EUR);
			converts.AddChild(UAH);
			converts.AddChild(RUB);
			menu.AddChild(converts);
			
			Composite settings =  new Composite("Settings", this);
			
			Composite methodTopUp =  new Composite("Top up the Phone", this);
			Invoker cashMethod = new Invoker("Cash Method", new CashTopUpCommand(this));
			Invoker cardMethod = new Invoker("Card Method", new CardTopUpCommand(this));
			Invoker BitCoinMethod = new Invoker("BitCoin Method", new BitCoinTopUpCommand(this));
			methodTopUp.AddChild(cashMethod);
			methodTopUp.AddChild(cardMethod);
			methodTopUp.AddChild(BitCoinMethod);
			
			Composite upgradeNotify = new Composite("Upgrade Account Notification ", this);
			Invoker email = new Invoker("Set EmailNotification", new EmailNotificationCommand(this));
			Invoker facebook = new Invoker("Set FaceBookNotification", new FacebookNotificationCommand(this));
			Invoker telegram = new Invoker("Set TelegramNotification", new TelegramNotificationCommand(this));
			upgradeNotify.AddChild(email);
			upgradeNotify.AddChild(facebook);
			upgradeNotify.AddChild(telegram);
			
			settings.AddChild(methodTopUp);
			settings.AddChild(upgradeNotify);
			menu.AddChild(settings);
			
			Invoker logOut = new Invoker("Log Out", new LogOutCommand(this));
			menu.AddChild(logOut);

			
			return menu;
		}

		private Composite CreateMainMenu()
		{
			Composite menu = new Composite("MainMenu", this, false);

			Composite info = new Composite("Info", this);
			Invoker aboutBank = new Invoker("About Us", new AboutBankCommand(this));
			Invoker contactBank = new Invoker("Contact Us", new ContactBankCommand(this));
			
			Invoker login = new Invoker("Login", new LoginCommand(this));
			Invoker signUp = new Invoker("Sign Up", new RegisterCommand(this));
			
			info.AddChild(aboutBank);
			info.AddChild(contactBank);
			menu.AddChild(info);
			menu.AddChild(login);
			menu.AddChild(signUp);
			return menu;
		}
	}
}