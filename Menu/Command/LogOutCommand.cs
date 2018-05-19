namespace console_bank_system.Menu.Command
{
	public class LogOutCommand : AbstractCommand
	{
		public LogOutCommand(Bank bank) : base(bank)
		{
		}

		public override bool Execute()
		{
			Bank.LogOut();
			return false;
		}
	}
}