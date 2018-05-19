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
			Bank bank = new Bank();
			bank.Start();
		}
	}
}