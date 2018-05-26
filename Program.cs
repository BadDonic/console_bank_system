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
			Bank bank =  new Bank("mongodb://BadDonic:qb9jzlqb@ds227740.mlab.com:27740/bank_db");
			Component menu = CreateMenu(bank);
			menu.Execute();
		}
		
		static Composite CreateMenu(Bank bank)
		{
			Console.WriteLine(bank);
			Composite menu = new Composite("MainMenu", bank);
			
			Composite info = new Composite("Info", bank, menu);
			info.AddChild(new Invoker("About Us", new AboutBankCommand(bank)));
			info.AddChild(new Invoker("Contact Us", new ContactBankCommand(bank)));
			
			Composite profile =  new Composite("Profile", bank, menu, Access.User);
			
			Composite converts =  new Composite("Convert", bank, profile);
			converts.AddChild(new Invoker("TO_USD", new ConvertToUSDCommand(bank)));
			converts.AddChild(new Invoker("TO_EUR", new ConvertToEURCommand(bank)));
			converts.AddChild(new Invoker("TO_UAH", new ConvertToUAHCommand(bank)));
			converts.AddChild(new Invoker("TO_RUB", new ConvertToRUBCommand(bank)));
			
			Composite settings =  new Composite("Settings", bank, profile);
			
			Composite methodTopUp =  new Composite("Top up the Phone", bank, settings);
			
			methodTopUp.AddChild(new Invoker("Cash Method", new CashTopUpCommand(bank)));
			methodTopUp.AddChild(new Invoker("Card Method", new CardTopUpCommand(bank)));
			methodTopUp.AddChild(new Invoker("BitCoin Method", new BitCoinTopUpCommand(bank)));
			
			Composite upgradeNotify = new Composite("Upgrade Account Notification ", bank, settings);
			upgradeNotify.AddChild(new Invoker("Set EmailNotification", new EmailNotificationCommand(bank)));
			upgradeNotify.AddChild(new Invoker("Set FaceBookNotification", new FacebookNotificationCommand(bank)));
			upgradeNotify.AddChild(new Invoker("Set TelegramNotification", new TelegramNotificationCommand(bank)));
			
			settings.AddChild(methodTopUp);
			settings.AddChild(upgradeNotify);
			
			profile.AddChild(new Invoker("Info", new AccountInfoCommand(bank)));
			profile.AddChild(new Invoker("Top Up The Phone", new TopUpCommand(bank)));
			profile.AddChild(new Invoker("Send Notification", new SendNotificationCommand(bank)));
			profile.AddChild(converts);
			profile.AddChild(settings);
			profile.AddChild(new Invoker("Log Out", new LogOutCommand(bank)));
			
			menu.AddChild(info);
			menu.AddChild(new Invoker("Login", new LoginCommand(bank), Access.OnlyGuest));
			menu.AddChild(new Invoker("Sign Up", new RegisterCommand(bank), Access.OnlyGuest));
			menu.AddChild(profile);
			menu.AddChild(new Invoker("Log Out", new LogOutCommand(bank), Access.User));
			return menu;
		}
	}
}