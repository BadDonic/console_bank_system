namespace console_bank_system.Menu.Command
{
	public class ConvertToEURCommand : AbstractCommand
	{
		public ConvertToEURCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account.ConvertToEUR();
			return true;
		}
	}
	
	public class ConvertToUSDCommand : AbstractCommand
	{
		public ConvertToUSDCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account.ConvertToUSD();
			return true;
		}
	}
	
	public class ConvertToUAHCommand : AbstractCommand
	{
		public ConvertToUAHCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account.ConvertToUAH();
			return true;
		}
	}
	
	public class ConvertToRUBCommand : AbstractCommand
	{
		public ConvertToRUBCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.Account.ConvertToRUB();
			return true;
		}
	}
}