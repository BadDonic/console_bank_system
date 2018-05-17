using System;
using console_bank_system.Menu.Command;

namespace console_bank_system.Menu
{
	public class Invoker : Component
	{
		private ICommand Command { get; set; }
		public Invoker(string name, ICommand command) : base(name)
		{
			Command = command;
		}

		public override bool Execute()
		{
			Console.Clear();
			Console.WriteLine("-----------------------------------------------");
			Console.WriteLine($"\t{Name}\t");
			Console.WriteLine("-----------------------------------------------");
			Command?.Execute();
			return false;
		}
	}
}