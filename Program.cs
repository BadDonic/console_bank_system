using System;
using System.Threading.Tasks;
using console_bank_system.Menu;
using console_bank_system.Menu.Command;

namespace console_bank_system
{
	class Program
	{
		static void Main(string[] args)
		{
			string mongodbURL = "mongodb://BadDonic:qb9jzlqb@ds227740.mlab.com:27740/bank_db";
			Bank bank = new Bank();
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