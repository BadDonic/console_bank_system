using System;
using console_bank_system.Menu.Command;

namespace console_bank_system.Menu
{
	public class Invoker : Component
	{
		private AbstractCommand Command { get; set; }
		public Invoker(string name, AbstractCommand command, Access access = Access.Default) : base(name, access)
		{
			Command = command;
		}

		public override bool Execute()
		{
			Console.Clear();
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine($"\t\t{Name}\t");
			Console.WriteLine("-----------------------------------------------");
			bool res = Command?.Execute() ?? true;
			return res;
		}
	}
}